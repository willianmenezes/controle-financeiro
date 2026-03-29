using ControleFinanceiro.Domain.Users;

namespace ControleFinanceiro.Application.Authentication;

public interface ITokenProvider
{
    string Create(User user);
}
