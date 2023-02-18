using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeployService
{
    internal class Startup
    {
        public Startup(IConfiguration configuration) { 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);  
            services.AddLogging();
            services.AddHealthChecks();
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
            //DI add all managers here
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IApplicationLifetime appLifetime, ILoggerFactory logFactory)
        {
            if(env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseRouting();   
            app.UseAuthentication();
            app.UseMvc();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
