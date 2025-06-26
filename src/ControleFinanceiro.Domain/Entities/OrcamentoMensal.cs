namespace ControleFinanceiro.Domain.Entities;

public sealed class OrcamentoMensal
{
    public Guid Id { get; }

    public int Mes { get; private set; }

    public int Ano { get; private set; }

    public decimal Saldo { get; private set; }

    public decimal TotalEntradas { get; private set; }

    public decimal TotalSaidas { get; private set; }

    public IEnumerable<OrcamentoDiario> OrcamentosDiarios { get; private set; } = [];

    public OrcamentoMensal(
        int mes,
        int ano)
    {
        Id = Guid.NewGuid();
        Mes = mes;
        Ano = ano;
        TotalEntradas = decimal.Zero;
        TotalSaidas = decimal.Zero;
    }
}