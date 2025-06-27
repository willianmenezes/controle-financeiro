using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra;

public static class InfraServiceCollectionExtensions
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddSingleton<IOrcamentoMensalRepository, OrcamentoMensalRepository>();
        return services;
    }
}