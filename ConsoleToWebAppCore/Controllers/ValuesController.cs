using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        [Route("~/api/Get-All")]
        //[Route("[controller]/[action]")]
        [Route("~/Get-All")]
        public string GetAll()
        {
            return "Hello from GetALL";
        }

        //[Route("api/Get-Author")]
        //[Route("[controller]/[action]")]
        public string GetAuthor()
        {
            return "Hello from GetAuthor";
        }

        //[Route("api/Get-Book/{id}")]
        [Route("{id}")]
        public string GetBooks(int id)
        {
            return "Hello Book id is "+id;
        }

        //[Route("api/Get-Book/{id}/author/{authorId}")]
        [Route("{id}/author/{authorId}")]
        public string GetBookByAuthor(int id, int authorId)
        {
            return "Hello Book id is " + id +"and Author id is "+authorId;
        }

        //[Route("api/Search")]
        [Route("{id}/author/{authorId}/name/{name}")]
        public string SearchByQueryString(int id, int authorId, string name)
        {
            return "Hello Book id is " + id + "and Author id is " + authorId + " "+name;
        }
    }
}
