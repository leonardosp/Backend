using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Test.Cross.Data;
using Test.Domain.Motos;
using Test.Domain.Motos.Interface;
using Test.Domain.Paged;

namespace Test.Infra.Repository.Motos;

public class MotoRepository : IMotoRepository
{
    private readonly BackendeTestContext _context;

    public MotoRepository(BackendeTestContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection ObterConexao() => _context.Database.GetDbConnection();

    public void Adicionar(Moto moto)
    {
        _context.Motos.Add(moto);
    }

    public void Atualizar(Moto moto)
    {
        _context.Motos.Update(moto);
    }

    public async Task<Moto> ObterPorId(Guid id)
    {
        return await _context.Motos.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<Moto> ObterPorPlaca(string placa)
    {
        return await _context.Motos.FirstOrDefaultAsync(x => x.Placa == placa).ConfigureAwait(false);
    }


    public async Task<PagedResult<Moto>> ObterTodos(int pageSize, int pageIndex, string query = null)
    {
        var sql = @$"SELECT * FROM Motos 
                      ORDER BY [Placa] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY 
                      SELECT COUNT(Id) FROM Motos 
        ";

        var multi = await _context.Database.GetDbConnection()
            .QueryMultipleAsync(sql);

        var motos = multi.Read<Moto>();
        var total = multi.Read<int>().FirstOrDefault();

        return new PagedResult<Moto>()
        {
            List = motos,
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
