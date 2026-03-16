using ControleFinanceiro.BuildingBlocks.Domain;

namespace ControleFinanceiro.BuildingBlocks.Infrastructure.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}