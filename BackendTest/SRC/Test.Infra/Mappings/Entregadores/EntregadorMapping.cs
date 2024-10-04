using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entregadores;

namespace Test.Infra.Mappings.Entregadores;

public class EntregadorMapping : IEntityTypeConfiguration<Entregador>
{
    public void Configure(EntityTypeBuilder<Entregador> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.NumeroCnh).IsUnique();
        builder.HasIndex(c => c.Cnpj).IsUnique();

        builder.ToTable("Motos");
    }
}
