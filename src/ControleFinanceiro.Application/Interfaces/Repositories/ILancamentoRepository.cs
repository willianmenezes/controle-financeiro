using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Interfaces.Repositories;

public interface ILancamentoRepository
{
    Task RegistrarAsync(Lancamento lancamento, CancellationToken cancellationToken);
}