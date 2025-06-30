using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Context;

namespace ControleFinanceiro.Infra.Repositories;

internal sealed class LancamentoRepository: ILancamentoRepository
{
    private readonly ControleFinanceiroContext _context;

    public LancamentoRepository(ControleFinanceiroContext context)
    {
        _context = context;
    }

    public async Task RegistrarAsync(Lancamento lancamento, CancellationToken cancellationToken)
    {
        await _context.Lancamentos.AddAsync(lancamento, cancellationToken);
    }
}