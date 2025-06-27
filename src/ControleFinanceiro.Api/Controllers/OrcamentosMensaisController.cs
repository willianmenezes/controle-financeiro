using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;
using ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/orcamentos-mensais")]
public class OrcamentosMensaisController : ControllerBase
{
    private readonly ICadastrarOrcamentoMensalHandler _cadastrarOrcamentoMensalHandler;
    private readonly IObterOrcamentosMensaisHandler _obterOrcamentosMensaisHandler;

    public OrcamentosMensaisController(
        ICadastrarOrcamentoMensalHandler cadastrarOrcamentoMensalHandler,
        IObterOrcamentosMensaisHandler obterOrcamentosMensaisHandler)
    {
        _cadastrarOrcamentoMensalHandler = cadastrarOrcamentoMensalHandler;
        _obterOrcamentosMensaisHandler = obterOrcamentosMensaisHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarOrcamentoMensalAsync(
        [FromBody] CadastrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cadastrarOrcamentoMensalHandler.HandleAsync(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterOrcamentosMensaisAsync(CancellationToken cancellationToken)
    {
        var response = await _obterOrcamentosMensaisHandler.HandleAsync(cancellationToken);
        return Ok(response);
    }
}