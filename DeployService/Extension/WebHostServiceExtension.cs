using DeployService.Service;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
