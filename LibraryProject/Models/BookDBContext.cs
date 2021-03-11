using System;
using Microsoft.EntityFrameworkCore;



namespace LibraryProject.Models
{
    //Class derived from DbContext (asp.net built in funciontality)
    public class BookDBContext : DbContext
    { //set up database to hold books
       public BookDBContext (DbContextOptions<BookDBContext> options) : base (options)
        {       //options = sets up which database you will use by passing in connection string

        }

        public DbSet<Book> Books { get; set; }
    }
}
