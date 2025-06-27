namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;

public interface IObterOrcamentosMensaisHandler
{
    Task<IEnumerable<ObterOrcamentoMensaisResponse>> HandleAsync(CancellationToken cancellationToken);
}