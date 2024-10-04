using Test.Cross.Data;
using Test.Domain.Paged;

namespace Test.Domain.Entregadores.Interface;

public interface IEntregadorRepository : IRepository<Entregador>
{
    Task<Entregador> ObterPorId(Guid id);
    Task<Entregador> ObterPorCnpj(string cnpj);
    Task<Entregador> ObterPorCnh(int cnh);
    Task<PagedResult<Entregador>> ObterTodos(int pageSize, int pageIndex, string query = null);
    void Adicionar(Entregador entregador);
    void Atualizar(Entregador entregador);
}
