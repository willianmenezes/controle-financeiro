using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.EntityConfig;

internal sealed class OrcamentoDiarioEntityConfig : IEntityTypeConfiguration<OrcamentoDiario>
{
    public void Configure(EntityTypeBuilder<OrcamentoDiario> builder)
    {
        builder.ToTable("OrcamentosDiarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired();
     
        builder.Property(x => x.Data)
            .HasColumnName("Data")
            .HasColumnType("timestamp")
            .IsRequired();
        
        builder.Property(x => x.OrcamentoMensalId)
            .HasColumnName("OrcamentoMensalId")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Ignore(x => x.Saldo);
        builder.Ignore(x => x.TotalEntradas);
        builder.Ignore(x => x.TotalSaidas);

        builder.HasOne(x => x.OrcamentoMensal)
            .WithMany(x => x.OrcamentosDiarios)
            .HasForeignKey(x => x.OrcamentoMensalId)
            .HasConstraintName("FK_OrcamentoDiario_OrcamentoMensal_OrcamentoMensalId");
    }
}