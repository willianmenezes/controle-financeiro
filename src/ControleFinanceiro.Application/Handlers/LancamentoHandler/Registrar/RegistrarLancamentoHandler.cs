using ControleFinanceiro.Application.Interfaces.Repositories;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.LancamentoHandler.Registrar;

internal class RegistrarLancamentoHandler : IRegistrarLancamentoHandler
{
    private readonly ILancamentoRepository _lancamentoRepository;

    public RegistrarLancamentoHandler(ILancamentoRepository lancamentoRepository)
    {
        _lancamentoRepository = lancamentoRepository;
    }

    public async Task<RegistrarLancamentoResponse> HandleAsync(RegistrarLancamentoRequest request, CancellationToken cancellationToken)
    {
        Lancamento lancamento = request;
        await _lancamentoRepository.RegistrarAsync(lancamento, cancellationToken);
        return new RegistrarLancamentoResponse { Id = lancamento.Id };
    }
}