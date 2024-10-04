using Test.Cross.Messages;
using Test.Domain.Paged;

namespace Test.Domain.Entregadores.Queries;

public class ObterTodosEntregadoresCommand : Querie<PagedResult<Entregador>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
