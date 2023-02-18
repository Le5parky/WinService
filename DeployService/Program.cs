using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Linq;
using DeployService.Configuration;
using DeployService;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using DeployService.Extension;

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

        var builder = CreateWebHostBuilder(args.Where(arg => arg != ConsoleCmd).ToArray());
        var host = builder.Build();
        if (isService)
            host.RunAsCustomService();
        else 
            host.Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var configDirectory = ConfigurationManager.AppSettings.Get("ConfigurationPath");
        var configBuilder = JsonConfigurationBuilder.BuildConfiguration(configDirectory);

        return WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(configBuilder)
            .UseStartup<Startup>();            ;

    }

}


