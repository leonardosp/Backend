using Test.Cross.Data;
using Test.Domain.Paged;

namespace Test.Domain.Alugueis.Interface;

public interface IAluguelRepository : IRepository<Aluguel>
{
    Task<Aluguel> ObterPorId(Guid id);
    Task<Aluguel> ObterAluguelPorMotoId(Guid motoId);
    Task<PagedResult<Aluguel>> ObterTodos(int pageSize, int pageIndex, string query = null);
    void Adicionar(Aluguel aluguel);
    void Atualizar(Aluguel aluguel);
}
