using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public interface IDatabaseContext
    {
        DbSet<TokenRegistration> TokenRegistrations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task CheckConnectionAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}