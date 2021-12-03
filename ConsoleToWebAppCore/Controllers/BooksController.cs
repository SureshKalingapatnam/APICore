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
    public class BooksController : ControllerBase
    {
        [Route("{id:int:min(10):max(100)}")]
        public string GetBooks(int id)
        {
            return "This is from Int Books " + id;
;       }

        //[Route("{id:length(6):alpha}")]
        [Route("{id:length(2):regex(a(b|c))}")]
        public string GetBooks(string id)
        {
            return "This is from string Books " + id;
            ;
        }

    }
}
