using ControleFinanceiro.Application.Authentication;
using ControleFinanceiro.Application.Data;
using ControleFinanceiro.Application.Messaging;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Users.GetByEmail;

internal sealed class GetUserByEmailQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetUserByEmailQuery, UserResponse>
{
    public async Task<ErrorOr<UserResponse>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        UserResponse? user = await context.Users
            .Where(u => u.Email == query.Email)
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

        if (user.Id != userContext.UserId)
        {
            return Error.Custom((int)ErrorType.Unauthorized, "","User not found");
        }

        return user;
    }
}
