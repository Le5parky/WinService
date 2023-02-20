using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployService.Service
{
    internal class AppDeployService:WebHostService
    {
        
        public AppDeployService(IWebHost host) : base(host)
        { 
        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }
        protected override void OnStarted()
        {
            base.OnStarted();
        }
        protected override void OnStopping()
        {
            base.OnStopping();
        }
        protected override void OnStopped()
        {
            base.OnStarted();
        }
    }
}
