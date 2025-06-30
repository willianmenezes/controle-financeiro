using ControleFinanceiro.Application.Handlers.CategoriaHandler.Registrar;
using ControleFinanceiro.Application.Handlers.LancamentoHandler.Registrar;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IObterOrcamentosMensaisHandler, ObterOrcamentosMensaisHandler>();
        services.AddScoped<IRegistrarOrcamentoMensalHandler, RegistrarOrcamentoMensalHandler>();

        services.AddScoped<IRegistrarCategoriaHandler, RegistrarCategoriaHandler>();

        services.AddScoped<IRegistrarLancamentoHandler, RegistrarLancamentoHandler>();
        return services;
    }
}