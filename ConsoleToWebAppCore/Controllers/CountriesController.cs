using ConsoleToWebAppCore.CustomBinder;
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
    //[BindProperties(SupportsGet =true)]
    public class CountriesController : ControllerBase
    {
        public CountryModel country { get; set; }

        [HttpPost("{Id}")]
        public IActionResult AddCountry([FromRoute] int Id,[FromHeader] string data, [FromForm] CountryModel country)
        {
            return Ok($"Country Name {country.Name} and Header data {data}");
        }

        [HttpGet("Search")]
        public IActionResult Search([ModelBinder(typeof(CustomeBinderModel))]string[] countries)
        {
            return Ok(countries);
        }

        [HttpGet("Append")]
        public IActionResult AppendText([ModelBinder(typeof(AppendModelBinder))] string InputVal)
        {
            return Ok(InputVal);
        }

        [HttpGet("SearchCountry/{Id}")]
        public IActionResult SearchCountry([ModelBinder(Name ="id")] CountryModel country)
        {
            return Ok(country);
        }

    }
}
