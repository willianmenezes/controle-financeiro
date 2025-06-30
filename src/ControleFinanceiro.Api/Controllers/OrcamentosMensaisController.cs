using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/orcamentos-mensais")]
public class OrcamentosMensaisController : ControllerBase
{
    private readonly IRegistrarOrcamentoMensalHandler _registrarOrcamentoMensalHandler;
    private readonly IObterOrcamentosMensaisHandler _obterOrcamentosMensaisHandler;

    public OrcamentosMensaisController(
        IRegistrarOrcamentoMensalHandler registrarOrcamentoMensalHandler,
        IObterOrcamentosMensaisHandler obterOrcamentosMensaisHandler)
    {
        _registrarOrcamentoMensalHandler = registrarOrcamentoMensalHandler;
        _obterOrcamentosMensaisHandler = obterOrcamentosMensaisHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarOrcamentoMensalAsync(
        [FromBody] RegistrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _registrarOrcamentoMensalHandler.HandleAsync(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterOrcamentosMensaisAsync(CancellationToken cancellationToken)
    {
        var response = await _obterOrcamentosMensaisHandler.HandleAsync(cancellationToken);
        return Ok(response);
    }
}