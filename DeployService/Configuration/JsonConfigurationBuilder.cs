using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployService.Configuration
{
    public static class JsonConfigurationBuilder
    {
        public static IConfiguration BuildConfiguration(string basePath)
        {
            var builder = new ConfigurationBuilder();
            if(!string.IsNullOrEmpty(basePath)) 
                builder.SetBasePath(basePath);

            builder
                .AddJsonFile("common.config.json", optional: true, reloadOnChange: true)
                .AddJsonFile("env.config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
            
        }
    }
}
