using System;
using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashlessRegistration.TokenService.App.Domain.Repositories
{
    public static class TokenRegistrationRepository
    {
        public static async Task<TokenRegistration> GetAsync(this DbSet<TokenRegistration> source, 
            long token, 
            DateTime registrationDate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await source.FirstOrDefaultAsync(x =>
                x.Id == token &&
                x.GeneratedAt == registrationDate, cancellationToken);
        }
    }
}
