using ControleFinanceiro.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
