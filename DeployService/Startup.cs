using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeployService
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
			services.AddLogging();
		}
		
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime, ILoggerFactory loggerFactory)
		{
			if (!env.IsDevelopment())
			{
				app.UseHsts();
			
				// var log4NetConfigurationPath = Path.Combine(ConfigurationManager.AppSettings.Get("ConfigurationPath"), "log4net.config");
				// loggerFactory.AddLog4Net(log4NetConfigurationPath);
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
    }
}
