namespace ControleFinanceiro.Domain.Entities;

public sealed class OrcamentoMensal
{
    public Guid Id { get; }

    public int Mes { get; private set; }

    public int Ano { get; private set; }

    public decimal Saldo => ObterSaldo();

    public decimal TotalEntradas => ObterTotalEntradas();

    public decimal TotalSaidas => ObterTotalSaidas();

    public IEnumerable<OrcamentoDiario> OrcamentosDiarios { get; private set; } = [];

    public OrcamentoMensal(
        int mes,
        int ano)
    {
        Id = Guid.NewGuid();
        Mes = mes;
        Ano = ano;
    }

    private decimal ObterTotalEntradas()
    {
        return OrcamentosDiarios
            .Where(o => o.Data.Month == Mes && o.Data.Year == Ano)
            .Sum(o => o.TotalEntradas);
    }

    private decimal ObterTotalSaidas()
    {
        return OrcamentosDiarios
            .Where(o => o.Data.Month == Mes && o.Data.Year == Ano)
            .Sum(o => o.TotalSaidas);
    }

    private decimal ObterSaldo()
    {
        return TotalEntradas - TotalSaidas;
    }
}