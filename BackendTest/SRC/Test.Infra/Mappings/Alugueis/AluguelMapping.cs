using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Alugueis;

namespace Test.Infra.Mappings.Alugueis;

public class AluguelMapping : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(f => f.Moto)
            .WithMany(e => e.Alugueis);

        builder.HasOne(c => c.Entregador)
               .WithMany(c => c.Alugueis);

        builder.ToTable("Alugueis");
    }
}
