using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ClientProject.Repository;
using NLog;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace ClientProject.Extensions
{
    public static class ExtensionsForLogs
    {
        public static  IServiceCollection AddServicesForLogs(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(LogManager.GetLogger("EtraLogger").GetType());
            services.AddTransient<IContextLogs>(x =>
            new ContextLogs(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != null ?
                configuration.GetConnectionString("ConnectForTest") : "", (Logger)x.GetService(typeof(Logger))));

            return services;
        }


    }

}
}
