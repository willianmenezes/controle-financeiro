using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Context;

namespace ControleFinanceiro.Infra.Repositories;

internal sealed class CategoriaRepository : ICategoriaRepository
{
    public IUnitOfWork UnitOfWork => _controleFinanceiroContext;
    private readonly ControleFinanceiroContext _controleFinanceiroContext;

    public CategoriaRepository(ControleFinanceiroContext controleFinanceiroContext)
    {
        _controleFinanceiroContext = controleFinanceiroContext;
    }


    public async Task RegistrarAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        await _controleFinanceiroContext.Categorias.AddAsync(categoria, cancellationToken);
    }
}