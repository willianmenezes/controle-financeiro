using ControleFinanceiro.Application.Messaging;

namespace ControleFinanceiro.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
