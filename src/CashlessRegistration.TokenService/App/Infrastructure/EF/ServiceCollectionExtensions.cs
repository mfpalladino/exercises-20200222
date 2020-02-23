using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashlessRegistration.TokenService.App.Infrastructure.EF
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContextPool<IDatabaseContext, DatabaseContext>(opt => opt.UseInMemoryDatabase(databaseName: "CashlessRegistrationInMemoryDatabase"));
        }
    }
}