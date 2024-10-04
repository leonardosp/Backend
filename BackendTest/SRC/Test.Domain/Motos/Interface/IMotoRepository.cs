using Test.Cross.Data;
using Test.Domain.Paged;

namespace Test.Domain.Motos.Interface;

public interface IMotoRepository : IRepository<Moto>
{
    Task<Moto> ObterPorId(Guid id);
    Task<Moto> ObterPorPlaca(string placa);
    Task<PagedResult<Moto>> ObterTodos(int pageSize, int pageIndex, string query = null);
    void Adicionar(Moto moto);
    void Atualizar(Moto moto);
}
