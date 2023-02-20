using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using DeployService.Configuration;
using DeployService;
using DeployService.Extension;
using AuthenticationSchemes = Microsoft.AspNetCore.Server.HttpSys.AuthenticationSchemes;

class Program
{

    private const string ConsoleCmd = "--console";
  		public static void Main(string[] args)
		{
			var isService = !(Debugger.IsAttached || args.Contains(ConsoleCmd));

			if (isService)
			{
				var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
				var pathToContentRoot = Path.GetDirectoryName(pathToExe);
				Directory.SetCurrentDirectory(pathToContentRoot);
			}

			var builder = CreateWebHostBuilder(
				args.Where(arg => arg != ConsoleCmd).ToArray());

			

			var host = builder.Build();

			if (isService)
			{
				// To run the app without the CustomWebHostService change the
				// next line to host.RunAsService();
				host.RunAsCustomService();
			}
			else
			{
				host.Run();
			}
        }

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			var configDirectory = ConfigurationManager.AppSettings.Get("ConfigurationPath");
			var configBuilder = JsonConfigurationBuilder.BuildConfiguration(configDirectory);

			return WebHost.CreateDefaultBuilder(args)
				.UseConfiguration(configBuilder)
				.UseStartup<Startup>()
				.UseHttpSys(options =>
				{
					options.Authentication.Schemes = AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
					options.Authentication.AllowAnonymous = true;
					options.MaxConnections = -1;
					options.MaxRequestBodySize = 30000000;
				});
		}
}

