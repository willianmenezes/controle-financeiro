using ControleFinanceiro.Application.Messaging;
using ControleFinanceiro.Application.Users.Login;

namespace ControleFinanceiro.Api.Endpoints.Users;

internal sealed class Login : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (
            Request request,
            ICommandHandler<LoginUserCommand, string> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            var result = await handler.Handle(command, cancellationToken);

            return result;
        })
        .WithTags(Tags.Users);
    }
}
