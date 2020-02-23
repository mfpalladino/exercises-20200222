using System.Threading;
using System.Threading.Tasks;
using CashlessRegistration.TokenService.App.Domain.Entities;
using CashlessRegistration.TokenService.App.Infrastructure.EF.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IEncryptionProviderLoader _encryptionProviderLoader;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            //TODO look how to inject this dependency
            _encryptionProviderLoader = EncryptionProviderLoaderAesSingleton.GetInstance();
        }

        public DbSet<TokenRegistration> TokenRegistrations { get; set; }
        public Task CheckConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            TokenRegistrations.FirstOrDefaultAsync(cancellationToken);
            return Task.CompletedTask;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(_encryptionProviderLoader.Load());
            modelBuilder.ApplyConfiguration(new TokenRegistrationMap());
        }
    }
}
