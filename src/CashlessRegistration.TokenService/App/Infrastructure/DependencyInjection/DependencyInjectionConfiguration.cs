using CashlessRegistration.TokenService.App.ApplicatonServices;
using CashlessRegistration.TokenService.App.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

namespace CashlessRegistration.TokenService.App.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Infrastructure
            services.AddSingleton<ISystemClock, SystemClock>();
            services.AddSingleton<ITokenGeneratorClock, TokenGeneratorDefaultClock>();
            services.AddSingleton<ITokenTtlChecker, TokenTtlDefaultChecker>();
            services.AddScoped<GeneralHealthCheckService>();

            //Domain services
            services.AddScoped<TokenCreateService>();
            services.AddScoped<TokenCheckService>();
            
            services.AddSingleton<ITokenGenerator, TokenDefaultGenerator>();
        }
    }
}
