namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Registrar;

public interface IRegistrarOrcamentoMensalHandler
{
    Task<RegistrarOrcamentoMensalResponse> HandleAsync(RegistrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken);
}