using ControleFinanceiro.Application.Authentication;
using ControleFinanceiro.Application.Data;
using ControleFinanceiro.Application.Messaging;
using ControleFinanceiro.Domain.Users;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Users.Login;

internal sealed class LoginUserCommandHandler(
    IApplicationDbContext context,
    IPasswordHasher passwordHasher,
    ITokenProvider tokenProvider) : ICommandHandler<LoginUserCommand, string>
{
    public async Task<ErrorOr<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (user is null)
        {
            Error.Custom((int)ErrorType.NotFound, "","User not found");
        }

        bool verified = passwordHasher.Verify(command.Password, user.PasswordHash);

        if (!verified)
        {
            Error.Custom((int)ErrorType.NotFound, "","User not found");
        }

        string token = tokenProvider.Create(user);

        return token;
    }
}
