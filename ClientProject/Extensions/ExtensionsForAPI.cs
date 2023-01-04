using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ClientProject.Repository;
using System.Net.Http;
using ClientProject.ServiceForApi;
using NLog;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ClientProject.Extensions
{
    public static class ExtensionsForAPI
    {
        public static IServiceCollection ExtensionsForAPISService(this IServiceCollection services) {
            services.AddScoped<HttpClient>();
            services.AddScoped<IServiceForApi<object>>(x => new ServiceForApi.ServiceForApi("http://localhost:26806/Home", x.GetService<HttpClient>()));
            return services;
        
        }
    }
}
