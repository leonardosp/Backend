using FluentValidation.Results;
using MediatR;
using Test.Cross.Messages;
using Test.Domain.Motos.Evento;
using Test.Domain.Motos.Interface;

namespace Test.Domain.Motos.Commands.Handler;

public class MotoCommandHandler : CommandHandler,
             IRequestHandler<RegistrarMotoCommand, ValidationResult>,
             IRequestHandler<AtualizarMotoCommand, ValidationResult>,
             IRequestHandler<RemoverMotoCommand, ValidationResult>

{
    private readonly IMotoRepository _motoRepository;

    public MotoCommandHandler(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<ValidationResult> Handle(RegistrarMotoCommand request, CancellationToken cancellationToken)
    {
        var moto = new Moto(request.Ano, request.Modelo, request.Placa);

        _motoRepository.Adicionar(moto);
        moto.AdicionarEvento(new MotoAdicionadaEvent(moto.Id, moto.Ano, moto.Modelo, moto.Placa));

        return await PersistirDados(_motoRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(AtualizarMotoCommand request, CancellationToken cancellationToken)
    {
        var moto = await _motoRepository.ObterPorId(request.Id);

        moto.AlterarPlaca(request.Placa);

        _motoRepository.Atualizar(moto);

        return await PersistirDados(_motoRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(RemoverMotoCommand request, CancellationToken cancellationToken)
    {
        var moto = await _motoRepository.ObterPorId(request.Id);

        moto.Excluir();

        _motoRepository.Atualizar(moto);

        return await PersistirDados(_motoRepository.UnitOfWork);
    }
}
