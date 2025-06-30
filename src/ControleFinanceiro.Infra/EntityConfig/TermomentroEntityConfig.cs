using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.EntityConfig;

internal class TermomentroEntityConfig : IEntityTypeConfiguration<Termometro>
{
    public void Configure(EntityTypeBuilder<Termometro> builder)
    {
        builder.ToTable("Termometros");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.ValorInicial)
            .HasColumnName("ValorInicial")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.ValorFinal)
            .HasColumnName("ValorFinal")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Cor)
            .HasColumnName("Cor")
            .HasColumnType("varchar(7)")
            .IsRequired();
    }
}