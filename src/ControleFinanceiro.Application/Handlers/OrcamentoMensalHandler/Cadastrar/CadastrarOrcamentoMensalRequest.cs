using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Cadastrar;

public sealed class CadastrarOrcamentoMensalRequest
{
    public int Mes { get; init; }
    
    public int Ano { get; init; }

    public static implicit operator OrcamentoMensal(CadastrarOrcamentoMensalRequest mensalRequest)
    {
        return new OrcamentoMensal(mensalRequest.Mes, mensalRequest.Ano);
    }
}