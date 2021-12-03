using BookStores.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetBooks();

        Task<BookModel> GetBook(int Id);

        Task<BookModel> AddBook(BookModel book);

        Task<BookModel> UpdateBook(int Id, BookModel book);

        Task<bool> DeleteBook(int Id);

        Task<BookModel> UpdatePatchBook(int Id, JsonPatchDocument book);
    }
}
