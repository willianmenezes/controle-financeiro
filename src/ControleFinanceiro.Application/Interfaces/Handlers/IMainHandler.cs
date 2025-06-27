namespace ControleFinanceiro.Application.Interfaces.Handlers;

public interface IMainHandler
{
    Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken);
}