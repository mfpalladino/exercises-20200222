using CashlessRegistration.TokenService.App.ApplicatonServices;
using CashlessRegistration.TokenService.App.Domain.Services;
using CashlessRegistration.TokenService.App.Infrastructure.EF;
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
            services.AddSingleton<IEncryptionProviderLoader, EncryptionProviderLoaderAes>();

            //Domain services
            services.AddSingleton<ITokenGeneratorClock, TokenGeneratorDefaultClock>();
            services.AddSingleton<ITokenTtlChecker, TokenTtlDefaultChecker>();
            services.AddSingleton<ITokenGenerator, TokenDefaultGenerator>();

            //Application services
            services.AddScoped<TokenCreateService>();
            services.AddScoped<TokenCheckService>();
            services.AddScoped<GeneralHealthCheckService>();
        }
    }
}
