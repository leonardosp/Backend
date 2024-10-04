using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Motos;

namespace Test.Infra.Mappings.Motos;

public class MotoMapping : IEntityTypeConfiguration<Moto>
{
    public void Configure(EntityTypeBuilder<Moto> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Placa).IsUnique();

        builder.ToTable("Motos");
    }
}
