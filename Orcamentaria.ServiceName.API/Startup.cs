using Orcamentaria.Lib.Domain.Validators;
using Orcamentaria.Lib.Infrastructure.Configures;
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
            services.AddServiceRegistryHosted(Configuration);

            services.ResolveCommonServicesWithMySql<MySqlContext>(
                configuration: Configuration,
                serviceName: _serviceName,
                apiVersion: _apiVersion,
                customServices: () =>
                {
                    services.AddAutoMapper(typeof(ExampleMapper));

                    services.AddScoped<IExampleRepository, ExampleRepository>();
                    services.AddScoped<IExampleService, ExampleService>();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.ConfigureCommon(env, _serviceName, _apiVersion);
    }
}
