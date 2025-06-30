using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.CategoriaHandler.Registrar;

internal class RegistrarCategoriaHandler : IRegistrarCategoriaHandler
{
    private readonly ICategoriaRepository _categoriaRepository;

    public RegistrarCategoriaHandler(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<RegistrarCategoriaResponse> HandleAsync(RegistrarCategoriaRequest request,
        CancellationToken cancellationToken)
    {
        Categoria categoria = request;
        await _categoriaRepository.RegistrarAsync(categoria, cancellationToken);
        await _categoriaRepository.UnitOfWork.CommitAsync(cancellationToken);
        return new RegistrarCategoriaResponse { Id = categoria.Id };
    }
}