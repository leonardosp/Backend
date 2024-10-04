using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Test.Cross.Data;
using Test.Cross.Mediator;
using Test.Cross.Messages;
using Test.Domain.Alugueis;
using Test.Domain.Entregadores;
using Test.Domain.Motos;
using Test.Infra.Extensions;

namespace Test.Infra;

public class BackendeTestContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public BackendeTestContext(DbContextOptions<BackendeTestContext> options, IMediatorHandler mediatorHandler)
        : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Aluguel> Alugueis { get; set; }
    public DbSet<Entregador> Entregadores { get; set; }
    public DbSet<Moto> Motos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        var sucesso = await base.SaveChangesAsync() > 0;
        if (sucesso) await _mediatorHandler.PublicarEventos(this);

        return sucesso;
    }
}