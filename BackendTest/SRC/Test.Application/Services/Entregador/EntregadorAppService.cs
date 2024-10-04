using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Test.Application.Base;
using Test.Application.Models;
using Test.Application.Services.Entregador.Interface;
using Test.Cross.Mediator;
using Test.Domain.Entregadores.Commands;
using Test.Domain.Entregadores.Queries;
using Test.Domain.Entregadores.Service;

namespace Test.Application.Services.Entregador;

public class EntregadorAppService : ApplicationBase, IEntregadorAppService
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EntregadorAppService(IMediatorHandler mediatorHandler, IMediator mediator, IMapper mapper)
    {
        _mediatorHandler = mediatorHandler;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ValidationResult> RegistrarEntregador(EntregadorViewModel entregadorViewModel)
    {
        var entregadorExiste = await EntregadorExiste(entregadorViewModel.NumeroCnh, entregadorViewModel.Cnpj);

        if (entregadorExiste)
        {
            AdicionarErroValidation($"Já existe entregador cadastrado com este Cnh: {entregadorViewModel.NumeroCnh} ou Cnpj: {entregadorViewModel.Cnpj}");
            return ValidationResult;
        }

        var command = _mapper.Map<RegistrarEntregadorCommand>(entregadorViewModel);

        return await _mediatorHandler.EnviarComando(command);
    }

    public async Task<ValidationResult> AtualizarFotoEntregador(AtualizarFotoEntregadorViewModel entregadorViewModel)
    {
        var entregadorExiste = await ObterPorId(entregadorViewModel.Id);

        if (entregadorExiste == null)
        {
            AdicionarErroValidation($"Não existe entregador cadastrado com Id: {entregadorViewModel.Id}");
            return ValidationResult;
        }

        var imgPrefixo = Guid.NewGuid() + "_";

        if (!await UploadArquivo(entregadorViewModel.ImagemUpload, imgPrefixo))
        {
            return ValidationResult;
        }

        var command = new AtualizarFotoEntregadorCommand(entregadorViewModel.Id, imgPrefixo + entregadorViewModel.ImagemUpload.FileName);

        return await _mediatorHandler.EnviarComando(command);
    }

    public async Task<EntregadorViewModel> ObterPorCnh(int cnh)
    {
        var command = new ObterEntregadorPorCnhCommand(cnh);

        return _mapper.Map<EntregadorViewModel>(await _mediator.Send(command));
    }

    public async Task<EntregadorViewModel> ObterPorCnpj(string cnpj)
    {
        var command = new ObterEntregadorPorCnpjCommand(cnpj);

        return _mapper.Map<EntregadorViewModel>(await _mediator.Send(command));
    }

    public async Task<EntregadorViewModel> ObterPorId(Guid id)
    {
        var command = new ObterEntregadorPorIdCommand(id);

        return _mapper.Map<EntregadorViewModel>(await _mediator.Send(command));
    }

    private async Task<bool> EntregadorExiste(int? cnh, string? cnpj)
    {
        var entregadorExiste = new EntregadorViewModel();

        if (cnh != null)
        {
            entregadorExiste = await ObterPorCnh(cnh.Value);
        }

        if (cnpj != string.Empty)
        {
            entregadorExiste = await ObterPorCnpj(cnpj);
        }

        if (entregadorExiste == null)
        {
            AdicionaErro($"Não foi possivel localizar entregador com esta Cnh: {cnh} ou Cnpj: {cnpj}");
            return false;
        }

        return true;
    }

    private async Task<bool> UploadArquivo(IFormFile arquivo, string nome)
    {
        if (arquivo == null || arquivo.Length == 0)
        {
            AdicionaErro("Forneça uma imagem para este produto!");
            return false;
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nome + arquivo.FileName);

        if (System.IO.File.Exists(path))
        {
            AdicionaErro("Já existe um arquivo com este nome!");
            return false;
        }

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        return true;
    }

    private void AdicionaErro(string message)
    {
        AdicionarErroValidation(message);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
