using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Test.Cross.Data;
using Test.Domain.Alugueis;
using Test.Domain.Alugueis.Interface;
using Test.Domain.Paged;

namespace Test.Infra.Repository.Alugueis;

public class AluguelRepository : IAluguelRepository
{
    private readonly BackendeTestContext _context;

    public AluguelRepository(BackendeTestContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection ObterConexao() => _context.Database.GetDbConnection();

    public void Adicionar(Aluguel aluguel)
    {
        _context.Alugueis.Add(aluguel);
    }

    public void Atualizar(Aluguel aluguel)
    {
        _context.Alugueis.Update(aluguel);
    }

    public async Task<Aluguel> ObterAluguelPorMotoId(Guid motoId)
    {
        return await _context.Alugueis.Include(a => a.Moto).FirstOrDefaultAsync(m => m.Moto.Id == motoId);
    }

    public async Task<Aluguel> ObterPorId(Guid id)
    {
        return await _context.Alugueis.Include(e => e.Entregador).Include(m => m.Moto).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResult<Aluguel>> ObterTodos(int pageSize, int pageIndex, string query = null)
    {
        var sql = @$"SELECT * FROM Alugueis 
                      ORDER BY [Nome] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY 
                      SELECT COUNT(Id) FROM Alugueis 
        ";

        var multi = await _context.Database.GetDbConnection()
            .QueryMultipleAsync(sql, new { Nome = query });

        var alugueis = multi.Read<Aluguel>();
        var total = multi.Read<int>().FirstOrDefault();

        return new PagedResult<Aluguel>()
        {
            List = alugueis,
            TotalResults = total,
            PageIndex = pageIndex,
            PageSize = pageSize,
            Query = query
        };
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
