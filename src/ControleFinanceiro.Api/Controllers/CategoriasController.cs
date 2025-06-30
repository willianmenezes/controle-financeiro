using ControleFinanceiro.Application.Handlers.CategoriaHandler.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{
    private readonly IRegistrarCategoriaHandler _registrarCategoriaHandler;

    public CategoriasController(IRegistrarCategoriaHandler registrarCategoriaHandler)
    {
        _registrarCategoriaHandler = registrarCategoriaHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarOrcamentoMensalAsync(
        [FromBody] RegistrarCategoriaRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _registrarCategoriaHandler.HandleAsync(request, cancellationToken);
        return Ok(response);
    }
}