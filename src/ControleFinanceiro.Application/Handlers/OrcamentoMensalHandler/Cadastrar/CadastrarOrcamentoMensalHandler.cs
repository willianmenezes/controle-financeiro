using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;

internal sealed class CadastrarOrcamentoMensalHandler : ICadastrarOrcamentoMensalHandler
{
    private readonly IOrcamentoMensalRepository _orcamentoMensalRepository;

    public CadastrarOrcamentoMensalHandler(IOrcamentoMensalRepository orcamentoMensalRepository)
    {
        _orcamentoMensalRepository = orcamentoMensalRepository;
    }

    public async Task<CadastrarOrcamentoMensalResponse> HandleAsync(CadastrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken)
    {
        OrcamentoMensal orcamento = request;
        await _orcamentoMensalRepository.RegistrarAsync(orcamento, cancellationToken);
        return new CadastrarOrcamentoMensalResponse { Id = orcamento.Id };
    }
}