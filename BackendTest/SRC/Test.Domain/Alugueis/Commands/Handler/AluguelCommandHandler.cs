using FluentValidation.Results;
using MediatR;
using Test.Cross.Messages;
using Test.Domain.Alugueis.Interface;
using Test.Domain.Entregadores.Interface;
using Test.Domain.Motos.Interface;

namespace Test.Domain.Alugueis.Commands.Handler;

public class AluguelCommandHandler : CommandHandler,
             IRequestHandler<RegistrarAluguelCommand, ValidationResult>

{
    private readonly IAluguelRepository _aluguelRepository;
    private readonly IEntregadorRepository _entregadorRepository;
    private readonly IMotoRepository _motoRepository;


    public AluguelCommandHandler(IAluguelRepository aluguelRepository, IEntregadorRepository entregadorRepository, IMotoRepository motoRepository)
    {
        _aluguelRepository = aluguelRepository;
        _entregadorRepository = entregadorRepository;
        _motoRepository = motoRepository;
    }

    public async Task<ValidationResult> Handle(RegistrarAluguelCommand request, CancellationToken cancellationToken)
    {
        var aluguel = new Aluguel(request.DataInicio, request.DataPrevisaoFim, request.DataDevolucao, request.DataTermino);
        aluguel.Entregador = await _entregadorRepository.ObterPorId(request.IdEntregador);
        aluguel.Moto = await _motoRepository.ObterPorId(request.IdMoto);

        _aluguelRepository.Adicionar(aluguel);

        return await PersistirDados(_aluguelRepository.UnitOfWork);
    }
}
