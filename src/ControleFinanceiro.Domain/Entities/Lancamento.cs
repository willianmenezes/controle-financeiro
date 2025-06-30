namespace ControleFinanceiro.Domain.Entities;

public sealed class Lancamento
{
    public Guid Id { get; private set; }

    public decimal Valor { get; private set; }

    public string Descricao { get; private set; }

    public DateTime Data { get; private set; }

    public Guid CategoriaId { get; private set; }
    
    public Guid OrcamentoDiarioId { get; private set; }

    public Categoria? Categoria { get; private set; }
    
    public OrcamentoDiario? OrcamentoDiario { get; private set; }

    public Lancamento(decimal valor, string descricao, DateTime data, Guid categoriaId, Guid orcamentoDiarioId)
    {
        Id = Guid.NewGuid();
        Valor = valor;
        Descricao = descricao;
        Data = data;
        CategoriaId = categoriaId;
        OrcamentoDiarioId = orcamentoDiarioId;
    }
}