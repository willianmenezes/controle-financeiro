using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Application.Handlers.CategoriaHandler.Registrar;

public sealed class RegistrarCategoriaRequest
{
    public string Nome { get; init; }
    
    public Tipo Tipo { get; init; }
    
    public static implicit operator Categoria(RegistrarCategoriaRequest request)
    {
        return new Categoria(request.Nome, request.Tipo);
    }
}