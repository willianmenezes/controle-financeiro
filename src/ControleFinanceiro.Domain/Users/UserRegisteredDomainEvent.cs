using ControleFinanceiro.Core;

namespace ControleFinanceiro.Domain.Users;

public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;
