using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orcamentaria.Lib.Domain.Validators;
using Orcamentaria.Lib.Infrastructure;
using Orcamentaria.ServiceName.Application.Services;
using Orcamentaria.ServiceName.Domain.Mappers;
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
            CommonDI.AddServiceRegistryHosted(services, Configuration);

            CommonDI.ResolveCommonServicesWithMySql<MySqlContext>(
                serviceName: _serviceName,
                apiVersion: _apiVersion,
                services: services,
                configuration: Configuration,
                customServices: () =>
                {
                    Configuration = CommonDI.ResolveConfigs(_serviceName, services, Configuration);
                    services.Replace(ServiceDescriptor.Singleton(Configuration));

                    //Mappers
                    services.AddAutoMapper(typeof(ExampleMapper));

                    //Repositories
                    services.AddScoped<IExampleRepository, ExampleRepository>();

                    //Services
                    services.AddScoped<IExampleService, ExampleService>();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			=> CommonDI.ConfigureCommon(_serviceName, _apiVersion, app, env);
    }
}
