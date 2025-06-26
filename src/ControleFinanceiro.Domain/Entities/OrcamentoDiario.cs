namespace ControleFinanceiro.Domain.Entities;

public class OrcamentoDiario
{
    public Guid Id { get; }

    public DateTime Data { get; private set; }

    public decimal Saldo { get; private set; }

    public decimal TotalEntradas { get; private set; }

    public decimal TotalSaidas { get; private set; }

    public IEnumerable<Termometro> Termometros { get; private set; } = [];

    public IEnumerable<Lancamento> Lancamentos { get; private set; } = [];

    public OrcamentoDiario(DateTime data)
    {
        Id = Guid.NewGuid();
        Data = data;
        TotalEntradas = decimal.Zero;
        TotalSaidas = decimal.Zero;
        Saldo = decimal.Zero;
    }
}