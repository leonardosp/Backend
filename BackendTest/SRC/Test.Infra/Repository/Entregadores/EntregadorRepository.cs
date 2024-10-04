using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Test.Cross.Data;
using Test.Domain.Entregadores;
using Test.Domain.Entregadores.Interface;
using Test.Domain.Paged;

namespace Test.Infra.Repository.Entregadores;

public class EntregadorRepository : IEntregadorRepository
{
    private readonly BackendeTestContext _context;

    public EntregadorRepository(BackendeTestContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection ObterConexao() => _context.Database.GetDbConnection();

    public void Adicionar(Entregador entregador)
    {
        _context.Entregadores.Add(entregador);
    }

    public void Atualizar(Entregador entregador)
    {
        _context.Entregadores.Update(entregador);
    }

    public async Task<Entregador> ObterPorId(Guid id)
    {
        return await _context.Entregadores.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    }

    public async Task<Entregador> ObterPorCnpj(string cnpj)
    {
        return await _context.Entregadores.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
    }

    public async Task<Entregador> ObterPorCnh(int cnh)
    {
        return await _context.Entregadores.FirstOrDefaultAsync(x => x.NumeroCnh == cnh);
    }

    public async Task<PagedResult<Entregador>> ObterTodos(int pageSize, int pageIndex, string query = null)
    {
        var sql = @$"SELECT * FROM Entregadores 
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY 
                      SELECT COUNT(Id) FROM Entregadores 
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
        ";

        var multi = await _context.Database.GetDbConnection()
            .QueryMultipleAsync(sql, new { Nome = query });

        var entregadores = multi.Read<Entregador>();
        var total = multi.Read<int>().FirstOrDefault();

        return new PagedResult<Entregador>()
        {
            List = entregadores,
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
