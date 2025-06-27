using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Infra.Repositories;

internal class OrcamentoMensalRepository : IOrcamentoMensalRepository
{
    private readonly List<OrcamentoMensal> _orcamentosMensais = new();

    public OrcamentoMensalRepository()
    {
    }

    public async Task RegistrarAsync(OrcamentoMensal orcamento, CancellationToken cancellationToken)
    {
        await Task.Run(() => { _orcamentosMensais.Add(orcamento); }, cancellationToken);
    }

    public Task<IEnumerable<OrcamentoMensal>> ObterAsync(CancellationToken cancellation)
    {
        return Task.Run(() => _orcamentosMensais.AsEnumerable(), cancellation);
    }
}