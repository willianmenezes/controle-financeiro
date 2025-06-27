using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Interfaces.Repositories;

public interface IOrcamentoMensalRepository
{
    Task RegistrarAsync(OrcamentoMensal orcamento, CancellationToken cancellationToken);

    Task<IEnumerable<OrcamentoMensal>> ObterAsync(CancellationToken cancellation);
}