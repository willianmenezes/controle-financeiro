namespace ControleFinanceiro.Domain.Entities;

public sealed class Lancamento
{
    public Guid Id { get; private set; }

    public decimal Valor { get; private set; }

    public string Descricao { get; private set; }

    public DateTime Data { get; private set; }

    public Guid CategoriaId { get; private set; }

    public Categoria Categoria { get; private set; }

    public Lancamento(decimal valor, string descricao, DateTime data, Guid categoriaId)
    {
        Id = Guid.NewGuid();
        Valor = valor;
        Descricao = descricao;
        Data = data;
        CategoriaId = categoriaId;
    }
}