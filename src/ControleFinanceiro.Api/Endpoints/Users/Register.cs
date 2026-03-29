using ControleFinanceiro.Application.Messaging;
using ControleFinanceiro.Application.Users.Register;

namespace ControleFinanceiro.Api.Endpoints.Users;

internal sealed class Register : IEndpoint
{
    public sealed record Request(string Email, string FirstName, string LastName, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (
            Request request,
            ICommandHandler<RegisterUserCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new RegisterUserCommand(
                request.Email,
                request.FirstName,
                request.LastName,
                request.Password);

            var result = await handler.Handle(command, cancellationToken);

            return result;
        })
        .WithTags(Tags.Users);
    }
}
