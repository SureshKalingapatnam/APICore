using BookStores.API.Models;
using BookStores.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            if (books.Count > 0)
                return Ok(books);
            else
                return NotFound("No Books found");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBook([FromRoute]int Id)
        {
            var books = await _bookRepository.GetBook(Id);
            if (books != null)
                return Ok(books);
            else
                return NotFound("No Books found");
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel book)
        {
            var books = await _bookRepository.AddBook(book);
            if (books != null)
                //return Ok(books);
                return CreatedAtAction(nameof(GetBook),
                    new { Id = books.Id, controller = "Books" }, books);
            else
                return NotFound("No Books found");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel book,
                                                    [FromRoute] int Id)
        {
            var books = await _bookRepository.UpdateBook(Id, book);
            if (books != null)
                //return Ok(books);
                return CreatedAtAction(nameof(GetBook),
                    new { Id = books.Id, controller = "Books" }, books);
            else
                return NotFound("No Books found");
        }

        [HttpDelete("{Id}")]
        public async Task<string> DeleteBook([FromRoute] int Id)
        {
            bool flag =  await _bookRepository.DeleteBook(Id);
            if (flag)                
                return "Deleted";
            else
                return "Not Deleted";
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdatePatchBook([FromBody] JsonPatchDocument jsonPatchDocument,
                                                    [FromRoute] int Id)
        {
            var books = await _bookRepository.UpdatePatchBook(Id, jsonPatchDocument);
            if (books != null)
                //return Ok(books);
                return CreatedAtAction(nameof(GetBook),
                    new { Id = books.Id, controller = "Books" }, books);
            else
                return NotFound("No Books found");
        }
    }
}
