using BookStores.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.API.Data
{
    public class BookStoreContext: DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=tcp:sureshsoftdb.database.windows.net,1433;Initial Catalog=SureshSoftDB;Persist Security Info=False;User ID=sysadmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
