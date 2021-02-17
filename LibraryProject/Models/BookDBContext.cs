using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Models
{
    public class BookDBContext : DbContext
    {
       public BookDBContext (DbContextOptions<BookDBContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
