using CashlessRegistration.TokenService.App.Infrastructure.DependencyInjection;
using CashlessRegistration.TokenService.App.Infrastructure.EF;
using CashlessRegistration.TokenService.App.Infrastructure.ErrorHandling;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashlessRegistration.TokenService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDependencyInjection();
            services.ConfigureDatabase();
            services.AddMvc(options =>
                {
                    options.Filters.Add(new ContractValidationFilter());
                    options.Filters.Add(new ExceptionHandlingAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
