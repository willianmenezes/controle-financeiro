﻿namespace ControleFinanceiro.Domain.Entities;

public class OrcamentoDiario
{
    public Guid Id { get; }

    public DateTime Data { get; private set; }

    public Guid OrcamentoMensalId { get; private set; }

    public decimal Saldo => ObterSaldo();

    public decimal TotalEntradas => ObterTotalEntradas();

    public decimal TotalSaidas => ObterTotalSaidas();

    public OrcamentoMensal? OrcamentoMensal { get; private set; }

    public IEnumerable<Lancamento> Lancamentos { get; private set; } = [];

    public OrcamentoDiario(DateTime data, Guid orcamentoMensalId)
    {
        Id = Guid.NewGuid();
        Data = data;
        OrcamentoMensalId = orcamentoMensalId;
    }

    private decimal ObterTotalEntradas()
    {
        return Lancamentos
            .Where(l => l.Data.Date == Data.Date && l.Categoria.Tipo == Enums.Tipo.Entrada)
            .Sum(l => l.Valor);
    }

    private decimal ObterTotalSaidas()
    {
        return Lancamentos
            .Where(l => l.Data.Date == Data.Date && l.Categoria.Tipo is Enums.Tipo.Saida or Enums.Tipo.Investimento)
            .Sum(l => l.Valor);
    }

    private decimal ObterSaldo()
    {
        return TotalEntradas - TotalSaidas;
    }
}