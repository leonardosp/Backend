using MediatR;
using Test.Cross.Messages;
using Test.Domain.Alugueis.Interface;
using Test.Domain.Alugueis.Queries;

namespace Test.Domain.Alugueis.Services.Repository;

public class AluguelQueriesHandler : CommandHandler,
             IRequestHandler<ObterAluguelPorIdCommand, Aluguel>,
             IRequestHandler<ObterAluguelPorMotoIdCommand, Aluguel>

{
    private readonly IAluguelRepository _aluguelRepository;

    public AluguelQueriesHandler(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public async Task<Aluguel> Handle(ObterAluguelPorIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _aluguelRepository.ObterPorId(request.Id);

        return result;
    }

    public async Task<Aluguel> Handle(ObterAluguelPorMotoIdCommand request, CancellationToken cancellationToken)
    {
        return await _aluguelRepository.ObterAluguelPorMotoId(request.MotoId);
    }
}
