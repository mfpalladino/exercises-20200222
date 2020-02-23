using CashlessRegistration.TokenService.App.Domain.Services;
using CashlessRegistration.TokenService.App.Infrastructure.Clock;
using CashlessRegistration.TokenService.App.Infrastructure.HealthCheck;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

namespace CashlessRegistration.TokenService.App.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Infrastructure
            services.AddSingleton<ISystemClock, SystemClock>();
            services.AddSingleton<ITokenClock, TokenClock>();
            services.AddScoped<GeneralHealthCheckService>();

            //Domain services
            services.AddScoped<TokenCreateService>();
            services.AddScoped<TokenCheckService>();
            
            services.AddSingleton<ITokenGeneratorStrategy, TokenGeneratorDefaultStrategy>();
        }
    }
}
