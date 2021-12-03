using ConsoleToWebAppCore.Models;
using ConsoleToWebAppCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("")]
        public List<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel{ Id=101, Name="Suresh"},
                new EmployeeModel{ Id=102, Name="Ramesh"}
            };
        }

        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
            if (id == 0)
                return NotFound();
            
            return Ok(new List<EmployeeModel>()
            {
                new EmployeeModel{ Id=101, Name="Suresh"},
                new EmployeeModel{ Id=102, Name="Ramesh"}
            });
        }

        [Route("{Id}/GetDetails")]
        public ActionResult<EmployeeModel> GetEmployeeBasicDetails(int Id)
        {
            if (Id == 0)
                return NotFound("Resource Not Found");
            return new EmployeeModel { Id = 101, Name = "Suresh" };
        }

        [HttpGet("")]
        public IActionResult GetName([FromServices] IProductRepository _productRepository)
        {
            var name = _productRepository.GetName();
            return Ok(name);
        }
    }
}
