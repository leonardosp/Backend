using MediatR;
using Test.Cross.Messages;
using Test.Domain.Motos.Interface;

namespace Test.Domain.Motos.Queries.Handler;

public class MotoQueriesHandler : CommandHandler,
             IRequestHandler<ObterMotoPorIdCommand, Moto>,
             IRequestHandler<ObterMotoPorPlacaCommand, Moto>
{
    private readonly IMotoRepository _motoRepository;

    public MotoQueriesHandler(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<Moto> Handle(ObterMotoPorIdCommand request, CancellationToken cancellationToken)
    {
        return await _motoRepository.ObterPorId(request.Id);
    }

    public async Task<Moto> Handle(ObterMotoPorPlacaCommand request, CancellationToken cancellationToken)
    {
        return await _motoRepository.ObterPorPlaca(request.Placa);
    }
}
