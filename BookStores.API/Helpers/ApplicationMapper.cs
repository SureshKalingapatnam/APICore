using AutoMapper;
using BookStores.API.Models;
using BookStores.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStores.API.Helpers
{
    public class ApplicationMapper: Profile
    {      
        public ApplicationMapper()
        {
            CreateMap<BookStores.API.Data.BookStoreContext, BookModel>().ReverseMap();
        }
    }
}
