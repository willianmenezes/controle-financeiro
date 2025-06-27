using ControleFinanceiro.Application.Interfaces.Repositories;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;

internal sealed class ObterOrcamentosMensaisHandler : IObterOrcamentosMensaisHandler
{
    private readonly IOrcamentoMensalRepository _orcamentoMensalRepository;

    public ObterOrcamentosMensaisHandler(IOrcamentoMensalRepository orcamentoMensalRepository)
    {
        _orcamentoMensalRepository = orcamentoMensalRepository;
    }
    
    public async Task<IEnumerable<ObterOrcamentoMensaisResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var orcamentos = await _orcamentoMensalRepository.ObterAsync(cancellationToken);
        return orcamentos.Select(orcamento => (ObterOrcamentoMensaisResponse)orcamento);
    }
}