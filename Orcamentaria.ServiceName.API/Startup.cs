using Microsoft.Extensions.DependencyInjection.Extensions;
using Orcamentaria.Lib.Domain.Validators;
using Orcamentaria.Lib.Infrastructure.Configures;
using Orcamentaria.ServiceName.Application.Services;
using Orcamentaria.ServiceName.Application.Validators;
using Orcamentaria.ServiceName.Domain.Mappers;
using Orcamentaria.ServiceName.Domain.Models;
using Orcamentaria.ServiceName.Domain.Repositories;
using Orcamentaria.ServiceName.Domain.Services;
using Orcamentaria.ServiceName.Infrastructure.Contexts;
using Orcamentaria.ServiceName.Infrastructure.Repositories;

namespace Orcamentaria.ServiceName.API
{
    public class Startup
    {
        private readonly string _serviceName = "Orcamentaria.ServiceName";
        private readonly string _apiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = services.ResolveConfigs(Configuration, _serviceName);

            services.Replace(ServiceDescriptor.Singleton(Configuration));

            services.AddServiceRegistryHosted(Configuration);

            services.ResolveCommonServicesWithMySql<MySqlContext>(
                configuration: Configuration,
                serviceName: _serviceName,
                apiVersion: _apiVersion,
                customServices: () =>
                {
                    //Mappers
                    services.AddAutoMapper(_ => { }, typeof(ExampleMapper));

                    services.AddScoped<IExampleRepository, ExampleRepository>();
                    services.AddScoped<IExampleService, ExampleService>();

                    //Validators
                    services.AddScoped<IValidatorEntity<Example>, ExampleValidator>();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.ConfigureCommon(env, _serviceName, _apiVersion);
    }
}
