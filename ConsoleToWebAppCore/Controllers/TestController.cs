using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
    [ApiController]
    [Route("Test/{action}")]
    public class TestController: ControllerBase
    {
        public string Get()
        {
            return "Hello from Get";
        }
        public string GetNew()
        {
            return "Hello from GetNew";
        }
    }
}
