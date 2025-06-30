using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.EntityConfig;

internal sealed class LancamentoEntityConfig : IEntityTypeConfiguration<Lancamento>
{
    public void Configure(EntityTypeBuilder<Lancamento> builder)
    {
        builder.ToTable("Lancamentos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Valor)
            .HasColumnName("Valor")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Data)
            .HasColumnName("Data")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(x => x.CategoriaId)
            .HasColumnName("CategoriaId")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.OrcamentoDiarioId)
            .HasColumnName("OrcamentoDiarioId")
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Lancamentos)
            .HasForeignKey(x => x.CategoriaId)
            .HasConstraintName("FK_Lancamentos_Categorias_CategoriaId");
        
        builder.HasOne(x => x.OrcamentoDiario)
            .WithMany(x => x.Lancamentos)
            .HasForeignKey(x => x.OrcamentoDiarioId)
            .HasConstraintName("FK_Lancamentos_OrcamentosDiarios_OrcamentoDiarioId");
    }
}