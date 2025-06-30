using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Registrar;

internal sealed class RegistrarOrcamentoMensalHandler : IRegistrarOrcamentoMensalHandler
{
    private readonly IOrcamentoMensalRepository _orcamentoMensalRepository;

    public RegistrarOrcamentoMensalHandler(IOrcamentoMensalRepository orcamentoMensalRepository)
    {
        _orcamentoMensalRepository = orcamentoMensalRepository;
    }

    public async Task<RegistrarOrcamentoMensalResponse> HandleAsync(RegistrarOrcamentoMensalRequest request,
        CancellationToken cancellationToken)
    {
        OrcamentoMensal orcamento = request;
        await _orcamentoMensalRepository.RegistrarAsync(orcamento, cancellationToken);
        return new RegistrarOrcamentoMensalResponse { Id = orcamento.Id };
    }
}