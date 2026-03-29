using ControleFinanceiro.Application.Authentication;
using ControleFinanceiro.Application.Data;
using ControleFinanceiro.Application.Messaging;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<ErrorOr<UserResponse>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        if (query.UserId != userContext.UserId)
        {
            return Error.Custom((int)ErrorType.Unauthorized, "","User not authorized");
        }

        UserResponse? user = await context.Users
            .Where(u => u.Id == query.UserId)
            .Select(u => new UserResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return Error.Custom((int)ErrorType.NotFound, "","User not found");
        }

        return user;
    }
}
