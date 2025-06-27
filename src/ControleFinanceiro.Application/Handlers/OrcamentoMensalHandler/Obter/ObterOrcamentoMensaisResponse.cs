using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Obter;

public sealed class ObterOrcamentoMensaisResponse
{
    public Guid Id { get; init; }

    public int Mes { get; init; }

    public int Ano { get; init; }

    public decimal Saldo { get; init; }

    public decimal TotalEntradas { get; init; }

    public decimal TotalSaidas { get; init; }

    public static implicit operator ObterOrcamentoMensaisResponse(OrcamentoMensal orcamento)
    {
        return new ObterOrcamentoMensaisResponse()
        {
            Id = orcamento.Id,
            Mes = orcamento.Mes,
            Ano = orcamento.Ano,
            Saldo = orcamento.Saldo,
            TotalEntradas = orcamento.TotalEntradas,
            TotalSaidas = orcamento.TotalSaidas
        };
    }
}