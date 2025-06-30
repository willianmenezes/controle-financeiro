using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Handlers.OrcamentoMensalHandler.Registrar;

public sealed class RegistrarOrcamentoMensalRequest
{
    public int Mes { get; init; }
    
    public int Ano { get; init; }

    public static implicit operator OrcamentoMensal(RegistrarOrcamentoMensalRequest mensalRequest)
    {
        return new OrcamentoMensal(mensalRequest.Mes, mensalRequest.Ano);
    }
}