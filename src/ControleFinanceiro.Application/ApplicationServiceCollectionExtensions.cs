using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IObterOrcamentosMensaisHandler, ObterOrcamentosMensaisHandler>();
        services.AddSingleton<ICadastrarOrcamentoMensalHandler, CadastrarOrcamentoMensalHandler>();
        return services;
    }
}