using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using Lemcube.Module.LemModule.Repository;
using Lemcube.Module.LemModule.Services;
using MudBlazor.Services;

namespace Lemcube.Module.LemModule.Startup
{
    public class LemModuleServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILemModuleService, ServerLemModuleService>();
            services.AddDbContextFactory<LemModuleContext>(opt => { }, ServiceLifetime.Transient);

            services.AddMudServices();
        }
    }
}
