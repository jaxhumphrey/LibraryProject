using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        BookId = 1,
                        Author = "Grayson Fattelah",
                        Publisher = "IS Wolves",
                        ISBN = "1234",
                        ClassCat = "Motivation/Frat Energy",
                        Price = 25.25
                    }

                  );
                context.SaveChanges();
            }
        }
    }
}
