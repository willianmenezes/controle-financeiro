namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;

public interface ICadastrarOrcamentoMensalHandler
{
    Task<CadastrarOrcamentoMensalResponse> HandleAsync(CadastrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken);
}