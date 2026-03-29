namespace ControleFinanceiro.Core;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
