namespace ControleFinanceiro.Application.Handlers.CategoriaHandler.Registrar;

public interface IRegistrarCategoriaHandler
{
    Task<RegistrarCategoriaResponse>
        HandleAsync(RegistrarCategoriaRequest request, CancellationToken cancellationToken);
}