using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleFinanceiro.Infra.Context;

internal class ControleFinanceiroContext : DbContext, IUnitOfWork

{
    private readonly IConfiguration _configuration;

    public ControleFinanceiroContext()
    {
    }

    public ControleFinanceiroContext(
        DbContextOptions<ControleFinanceiroContext> options,
        IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ControleFinanceiroDbConnection"));

#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
#endif
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleFinanceiroContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveColumnType("varchar(100)");

        base.ConfigureConventions(configurationBuilder);
    }

    public DbSet<OrcamentoMensal> OrcamentosMensais { get; set; }

    public DbSet<OrcamentoDiario> OrcamentosDiarios { get; set; }

    public DbSet<Lancamento> Lancamentos { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Termometro> Termomentros { get; set; }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
}