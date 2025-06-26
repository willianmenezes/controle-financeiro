namespace ControleFinanceiro.Domain.Entities;

public sealed class Termometro
{
    public Guid Id { get; }

    public decimal ValorInicial { get; private set; }

    public decimal ValorFinal { get; private set; }

    public string Cor { get; private set; }

    public IEnumerable<OrcamentoMensal>? Orcamentos { get; private set; } = [];

    public Termometro(
        decimal valorInicial,
        decimal valorFinal,
        string cor)
    {
        Id = Guid.NewGuid();
        ValorInicial = valorInicial;
        ValorFinal = valorFinal;
        Cor = cor;
    }

    public void AtualizarValores(
        decimal valorInicial,
        decimal valorFinal)
    {
        ValorInicial = valorInicial;
        ValorFinal = valorFinal;
    }

    public void AtualizarCor(string cor)
    {
        Cor = cor;
    }
}