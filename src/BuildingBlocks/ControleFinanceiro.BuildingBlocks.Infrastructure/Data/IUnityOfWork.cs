namespace ControleFinanceiro.BuildingBlocks.Infrastructure.Data;

public interface IUnityOfWork
{
    Task<bool> CommitAsync(
        CancellationToken cancellationToken = default);
}