using AutoMapper;
using BookStores.API.Data;
using BookStores.API.Helpers;
using BookStores.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public IMapper _applicationMapper;

        public BookRepository(BookStoreContext bookStoreContext, IMapper applicationMapper)
        {
            _bookStoreContext = bookStoreContext;
            _applicationMapper = applicationMapper;
        }
        public async Task<List<BookModel>> GetBooks()
        {
            // return await _bookStoreContext.Books.ToListAsync();
            var books =await _bookStoreContext.Books.Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();
            return books;
        }

        public async Task<BookModel> GetBook(int Id)
        {
            //Books book = await _bookStoreContext.Books.FindAsync(Id);
            //BookModel book = await _bookStoreContext.Books.Where(x => x.Id == Id).Select(x => new BookModel
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();
            //return book;
            var book = await _bookStoreContext.Books.FindAsync(Id);
            return _applicationMapper.Map<BookModel>(book);
        }

        public async Task<BookModel> AddBook(BookModel book)
        {
            var bookData = new BookModel()
            {
                Title = book.Title,
                Description = book.Description
            };
           await _bookStoreContext.Books.AddAsync(bookData);
           await _bookStoreContext.SaveChangesAsync();
           return await _bookStoreContext.Books.Where(x => x.Id == bookData.Id).Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();
        }

        public async Task<BookModel> UpdateBook(int Id, BookModel book)
        {
            //var bookData =await _bookStoreContext.Books.FindAsync(Id);
            //if(bookData != null)
            //{
            //    bookData.Title = book.Title;
            //    bookData.Description = book.Description;
            //}
            //
            var bookData = new BookModel()
            {
                Id= Id,
                Title = book.Title,
                Description = book.Description
            };
            _bookStoreContext.Books.Update(bookData);
            await _bookStoreContext.SaveChangesAsync();
            return bookData;
        }

        public async Task<bool> DeleteBook(int Id)
        {
            //var bookData = await _bookStoreContext.Books.FindAsync(Id);
            var bookData = new BookModel()
            {
                Id= Id
            };
            if (bookData != null)
            {
                _bookStoreContext.Remove(bookData);
                await _bookStoreContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<BookModel> UpdatePatchBook(int Id, JsonPatchDocument jsonPatchDocument)
        {
            var book = await _bookStoreContext.Books.FindAsync(Id);
            if(book != null)
            {
                jsonPatchDocument.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
                return book;
            }
            return null;
        }
    }
}
