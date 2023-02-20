using Microsoft.Extensions.Configuration;
using DeployService.Configuration.Interface;

namespace DeployService.Configuration
{
    public class DeployServiceConfiguration:IDeployServiceConfiguration
    {
        private readonly IConfiguration _configuration;
        public DeployServiceConfiguration(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        protected string GetConfigurationPropertyInternal(string propertyName)
        {
            return _configuration?.GetSection(propertyName).Value;
        }
    }
}