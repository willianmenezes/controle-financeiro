using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repositories;

internal class OrcamentoMensalRepository : IOrcamentoMensalRepository
{
    private readonly ControleFinanceiroContext _context;

    public OrcamentoMensalRepository(ControleFinanceiroContext context)
    {
        _context = context;
    }

    public async Task RegistrarAsync(OrcamentoMensal orcamento, CancellationToken cancellationToken)
    {
        await _context.OrcamentosMensais.AddAsync(orcamento, cancellationToken);
    }

    public async Task<IEnumerable<OrcamentoMensal>> ObterAsync(CancellationToken cancellation)
    {
        return await _context.OrcamentosMensais 
            .AsNoTracking()
            .ToListAsync(cancellation);
    }
}