using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ClientProject.Repository;
using NLog;
using ClientProject.Extensions;
using ClientProject.ServiceForApi;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ClientProject
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration _configuration) => configuration = _configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddMvc();
            //создал расширение и добавил по логу все туда
            services.AddServicesForLogs(configuration);
            services.ExtensionsForAPISService();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        


    }
}
