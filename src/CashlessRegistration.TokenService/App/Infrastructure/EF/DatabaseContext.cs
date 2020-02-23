using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Entities;
using CashlessRegistration.TokenService.App.Infrastructure.EF.Map;
using Microsoft.EntityFrameworkCore;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TokenRegistration> TokenRegistrations { get; set; }
        public Task CheckConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            TokenRegistrations.FirstOrDefaultAsync(cancellationToken);
            return Task.CompletedTask;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TokenRegistrationMap());
        }
    }
}
