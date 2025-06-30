using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Infra.Context;
using ControleFinanceiro.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra;

public static class InfraServiceCollectionExtensions
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ControleFinanceiroContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ControleFinanceiroDbConnection")));
        
        services.AddScoped<IOrcamentoMensalRepository, OrcamentoMensalRepository>();
        services.AddScoped<ILancamentoRepository, LancamentoRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        return services;
    }
}