using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.LancamentoHandler.Registrar;

public sealed class RegistrarLancamentoRequest
{
    public decimal Valor { get; init; }

    public string Descricao { get; init; }

    public DateTime Data { get; init; }

    public Guid CategoriaId { get; init; }

    public Guid OrcamentoDiarioId { get; init; }
    
    public static implicit operator Lancamento(RegistrarLancamentoRequest request)
    {
        return new Lancamento(
            request.Valor,
            request.Descricao,
            request.Data,
            request.CategoriaId,
            request.OrcamentoDiarioId);
    }
}