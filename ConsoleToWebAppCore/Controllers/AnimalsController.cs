using ConsoleToWebAppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
    [Route("api/[controller]", Name ="All")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        List<Animals> animals = null;
        public AnimalsController()
        {
            animals = new List<Animals>()
            {
                new Animals{ Id=101, Name="Dog" },
                new Animals{ Id=102, Name="Cat" }
            };
        }
        [Route("")]
        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }

        [Route("Test")]
        public IActionResult GetlocalRedirect()
        {
            //return LocalRedirect("~/api/animals");
            return LocalRedirectPermanent("~/api/animals");
        }
        [Route("TestAnimal")]
        public IActionResult GetDetails()
        {
            //return Accepted("~/api/animals");
            //return AcceptedAtAction("GetAnimals");
            return AcceptedAtRoute("All");
        }

        [Route("{name}")]
        public IActionResult GetAnimalDetails(string name)
        {
            if (!name.Contains("ABC"))
                return BadRequest();
            return Ok(animals);
        }

        [Route("{Id:int}")]
        public IActionResult GetAnimalDetails(int Id)
        {
            if (Id == 0)
                return BadRequest();
            var animal = animals.FirstOrDefault(x => x.Id == Id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }

        [HttpPost("")]
        public IActionResult AddAnimal(Animals animal)
        {
            animals.Add(animal);
            //return Created("~/api/animals/" + animal.Id, animal);
            return CreatedAtAction("GetAnimalDetails", new { Id = animal.Id }, animal);
        }
    }
}
