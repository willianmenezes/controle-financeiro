using ControleFinanceiro.Domain.Enums;

namespace ControleFinanceiro.Domain.Entities;

public sealed class Categoria
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public Tipo Tipo { get; private set; }

    public IEnumerable<Lancamento> Lancamentos { get; private set; } = [];
}