using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Test.Application.Base;
using Test.Application.Models;
using Test.Application.Services.Motos.Interface;
using Test.Domain.Motos.Commands;
using Test.Domain.Motos.Queries;

namespace Test.Application.Services.Motos;

public class MotoAppService : ApplicationBase, IMotoAppService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MotoAppService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ValidationResult> AtualizarPlacaMoto(Guid id, string placa)
    {
        var command = new AtualizarMotoCommand(id, placa);

        var motoExiste = await MotoExiste(id, placa: string.Empty);

        if (!motoExiste)
        {
            return ValidationResult;
        }

        return await _mediator.Send(command);
    }

    public async Task<ValidationResult> RegistrarMoto(MotoViewModel motoViewModel)
    {
        var motoExiste = await MotoExiste(Guid.Empty, placa: motoViewModel.Placa);

        if (motoExiste)
        {
            AdicionarErroValidation($"Já existe moto cadastrada com esta Placa: {motoViewModel.Placa}");
            return ValidationResult;
        }

        var command = _mapper.Map<RegistrarMotoCommand>(motoViewModel);

        return await _mediator.Send(command);
    }

    public async Task<ValidationResult> RemoverMotoPorId(Guid id)
    {
        var motoExiste = await MotoExiste(Guid.Empty, placa: string.Empty);

        if (!motoExiste)
        {
            return ValidationResult;
        }

        var command = new RemoverMotoCommand(id);

        return await _mediator.Send(command);
    }

    public async Task<MotoViewModel> ObterMotoPorId(Guid id)
    {
        var command = new ObterMotoPorIdCommand(id);

        var result = await _mediator.Send(command);

        return _mapper.Map<MotoViewModel>(result);
    }

    public async Task<MotoViewModel> ObterMotoPorPlaca(string placa)
    {
        var command = new ObterMotoPorPlacaCommand(placa);

        var result = await _mediator.Send(command);

        return _mapper.Map<MotoViewModel>(result);
    }

    private async Task<bool> MotoExiste(Guid? id, string? placa)
    {
        var motoExiste = new MotoViewModel();

        if (id != Guid.Empty)
        {
            motoExiste = await ObterMotoPorId(id.Value);
        }

        if (placa != string.Empty)
        {
            motoExiste = await ObterMotoPorPlaca(placa);
        }

        if (motoExiste == null)
        {
            AdicionaErro($"Não foi possivel localizar moto com este Id: {id} ou placa: {placa}");
            return false;
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
