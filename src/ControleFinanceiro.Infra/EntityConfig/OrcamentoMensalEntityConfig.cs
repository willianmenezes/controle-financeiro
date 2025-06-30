using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.EntityConfig;

internal sealed class OrcamentoMensalEntityConfig : IEntityTypeConfiguration<OrcamentoMensal>
{
    public void Configure(EntityTypeBuilder<OrcamentoMensal> builder)
    {
        builder.ToTable("OrcamentosMensais");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Mes)
            .HasColumnName("Mes")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Ano)
            .HasColumnName("Ano")
            .HasColumnType("int")
            .IsRequired();

        builder.Ignore(x => x.Saldo);
        builder.Ignore(x => x.TotalEntradas);
        builder.Ignore(x => x.TotalSaidas);
    }
}