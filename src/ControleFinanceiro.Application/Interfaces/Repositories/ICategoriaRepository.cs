using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Interfaces.Repositories;

public interface ICategoriaRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task RegistrarAsync(Categoria categoria, CancellationToken cancellationToken);
}