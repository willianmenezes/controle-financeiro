using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Infra.Repositories;

public sealed class LancamentoRepository: ILancamentoRepository
{
    public async Task RegistrarAsync(Lancamento lancamento, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}