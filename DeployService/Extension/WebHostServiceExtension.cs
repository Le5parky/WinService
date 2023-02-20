using DeployService.Service;
using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace DeployService.Extension
{
    public static class WebHostServiceExtension
    {
        public static void RunAsCustomService(this IWebHost host) {
            var customWebService = new AppDeployService(host);
            ServiceBase.Run(customWebService);
        }

    }
}
