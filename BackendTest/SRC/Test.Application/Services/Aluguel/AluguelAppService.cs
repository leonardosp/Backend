using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using Test.Application.Base;
using Test.Application.Models;
using Test.Application.Services.Aluguel.Interface;
using Test.Application.Services.Entregador.Interface;
using Test.Domain.Alugueis.Commands;
using Test.Domain.Alugueis.Services;

namespace Test.Application.Services.Aluguel;

public class AluguelAppService : ApplicationBase, IAluguelAppService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IEntregadorAppService _entregadorAppService;

    private readonly IList<(decimal, int)> DaysAndValues = new List<(decimal, int)>
    {
        (30, 7),
        (28m, 15),
        (30m, 22),
        (45m, 20),
        (50m, 18),
    };

    public AluguelAppService(IMediator mediator, IMapper mapper, IEntregadorAppService entregadorAppService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _entregadorAppService = entregadorAppService;
    }

    public async Task<AluguelViewModel> ObterAluguelPorId(Guid id)
    {
        var command = new ObterAluguelPorIdCommand(id);

        var aluguel = await _mediator.Send(command);

        return _mapper.Map<AluguelViewModel>(aluguel);
    }

    public async Task<AluguelViewModel> ObterValorAluguel(Guid id, DateTime dataDevolucao)
    {
        var aluguelExiste = await ObterAluguelPorId(id);

        if (aluguelExiste == null)
        {
            AdicionarErroValidation($"Não foi possivel localizar nenhum aluguel com este Id: {id}");
        }

        if (dataDevolucao < aluguelExiste.DataDevolucao)
        {
            var totalDays = Math.Abs((aluguelExiste.DataInicio - aluguelExiste.DataTermino).TotalDays);
            var diasFaltantes = Math.Abs((aluguelExiste.DataTermino - dataDevolucao).TotalDays);
            var valorDiaria = ObtemValor(totalDays);

            aluguelExiste.ValorPrevisto = valorDiaria * Convert.ToDecimal(totalDays);
            aluguelExiste.ValorTotal = Multa(diasFaltantes, aluguelExiste.ValorPrevisto.GetValueOrDefault(), totalDays);
        }

        if(dataDevolucao > aluguelExiste.DataDevolucao)
        {
            var totalDays = Math.Abs((aluguelExiste.DataInicio - aluguelExiste.DataTermino).TotalDays);
            var diasAMais = Math.Abs((aluguelExiste.DataTermino - dataDevolucao).TotalDays);
            var valorDiaria = ObtemValor(totalDays);

            aluguelExiste.ValorPrevisto = valorDiaria * Convert.ToDecimal(totalDays);
            aluguelExiste.ValorTotal = valorDiaria + Convert.ToDecimal(diasAMais * 50);
        }

        return aluguelExiste;
    }

    public async Task<ValidationResult> RegistrarAluguel(AluguelViewModel aluguelViewModel)
    {
        var aluguelValido = await ValidaAluguel(aluguelViewModel);

        if (!aluguelValido)
        {
            return ValidationResult;
        }

        var command = _mapper.Map<RegistrarAluguelCommand>(aluguelViewModel);

        return await _mediator.Send(command);
    }

    private async Task<bool> ValidaAluguel(AluguelViewModel aluguelViewModel)
    {
        if (aluguelViewModel.DataInicio.Day > DateTime.Today.AddDays(1).Day)
        {
            AdicionarErroValidation("A data inicio locação tem que ser 1(um) dia após a data atual");
            return false;
        }

        var entregador = await _entregadorAppService.ObterPorId(aluguelViewModel.EntregadorId);

        if (entregador == null)
        {
            AdicionarErroValidation($"Não foi possivel localizar nenhum entregador com este Id: {aluguelViewModel.EntregadorId}");
            return false;
        }

        if (entregador.TipoCnh == TTest.Application.Models.enums.CnhTipoViewModel.B)
        {
            AdicionarErroValidation("Esse entregador não esta habilitado corretamente para realizar um aluguel");
            return false;
        }

        return true;
    }

    private decimal ObtemValor(double days)
    {
        if (days > 50) return DaysAndValues.Last().Item1;

        return DaysAndValues.First(x => days <= x.Item2).Item1;
    }

    private decimal Multa(double days, decimal valorContrato, double diasTotalContrato)
    {
        if(diasTotalContrato <= 7)
        {
            return (valorContrato + (Convert.ToDecimal(days) * 0.2m));
        }
        else
        {
            return (valorContrato + (Convert.ToDecimal(days) * 0.4m));
        }
    }

    private decimal ObtemValorContrato(DateTime dataInicio, DateTime dataPrevisaoFim)
    {
        var totalDays = (dataInicio - dataPrevisaoFim).TotalDays;

        var valorDiaria = ObtemValor(totalDays);

        var totalContrato = valorDiaria * Convert.ToDecimal(totalDays);

        return totalContrato;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
