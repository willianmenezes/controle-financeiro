using ControleFinanceiro.Api.Extensions;
using ControleFinanceiro.Application.Messaging;
using ControleFinanceiro.Application.Users.GetById;

namespace ControleFinanceiro.Api.Endpoints.Users;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (
            Guid userId,
            IQueryHandler<GetUserByIdQuery, UserResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUserByIdQuery(userId);

            var result = await handler.Handle(query, cancellationToken);

            return result;
        })
        .HasPermission(Permissions.UsersAccess)
        .WithTags(Tags.Users);
    }
}
