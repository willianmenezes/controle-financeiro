using ControleFinanceiro.Application.Messaging;

namespace ControleFinanceiro.Application.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
