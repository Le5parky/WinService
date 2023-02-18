using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployService.Contorller
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    internal class AppDeployController:ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World";
        }
    }
}
