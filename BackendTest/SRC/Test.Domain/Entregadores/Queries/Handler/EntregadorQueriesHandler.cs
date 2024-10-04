using MediatR;
using Test.Cross.Messages;
using Test.Domain.Entregadores.Interface;
using Test.Domain.Entregadores.Queries;
using Test.Domain.Paged;

namespace Test.Domain.Entregadores.Service.Repository;

public class EntregadorQueriesHandler : CommandHandler,
             IRequestHandler<ObterEntregadorPorIdCommand, Entregador>,
             IRequestHandler<ObterEntregadorPorCnhCommand, Entregador>,
             IRequestHandler<ObterEntregadorPorCnpjCommand, Entregador>,
             IRequestHandler<ObterTodosEntregadoresCommand, PagedResult<Entregador>>
{
    private readonly IEntregadorRepository _entregadorRepository;

    public EntregadorQueriesHandler(IEntregadorRepository entregadorRepository)
    {
        _entregadorRepository = entregadorRepository;
    }

    public async Task<Entregador> Handle(ObterEntregadorPorIdCommand request, CancellationToken cancellationToken)
    {
        return await _entregadorRepository.ObterPorId(request.Id);
    }

    public async Task<Entregador> Handle(ObterEntregadorPorCnhCommand request, CancellationToken cancellationToken)
    {
        return await _entregadorRepository.ObterPorCnh(Convert.ToInt32(request.Cnh));
    }

    public async Task<Entregador> Handle(ObterEntregadorPorCnpjCommand request, CancellationToken cancellationToken)
    {
        return await _entregadorRepository.ObterPorCnpj(request.Cnpj.ToString());
    }

    public async Task<PagedResult<Entregador>> Handle(ObterTodosEntregadoresCommand request, CancellationToken cancellationToken)
    {
        return await _entregadorRepository.ObterTodos(request.PageSize, request.PageIndex);
    }
}
