using ControleFinanceiro.Application.Authentication;
using ControleFinanceiro.Application.Data;
using ControleFinanceiro.Application.Messaging;
using ControleFinanceiro.Domain.Users;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Users.Register;

internal sealed class RegisterUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<ErrorOr<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await context.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
        {
            Error.Custom((int)ErrorType.Validation, "","Email unique");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            PasswordHash = passwordHasher.Hash(command.Password)
        };

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
