namespace ControleFinanceiro.Application.Handlers.LancamentoHandler.Registrar;

public interface IRegistrarLancamentoHandler
{
    Task<RegistrarLancamentoResponse> HandleAsync(RegistrarLancamentoRequest request,
        CancellationToken cancellationToken);
}