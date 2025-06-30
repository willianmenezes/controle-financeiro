using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IObterOrcamentosMensaisHandler, ObterOrcamentosMensaisHandler>();
        services.AddScoped<ICadastrarOrcamentoMensalHandler, CadastrarOrcamentoMensalHandler>();
        return services;
    }
}