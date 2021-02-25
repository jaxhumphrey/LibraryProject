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
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        ClassCat = "Fiction, Classic",
                        Price = 9.95,
                        NumPages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        ClassCat = "Non-Fiction, Biography",
                        Price = 14.58,
                        NumPages = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        ClassCat = "Non-Fiction, Biography",
                        Price = 21.54,
                        NumPages = 976
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        ClassCat = "Non-Fiction, Biography",
                        Price = 11.61,
                        NumPages = 832
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        ClassCat = "Non-Fiction, Historical",
                        Price = 13.33,
                        NumPages = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0812981254",
                        ClassCat = "Fiction, Historical fiction",
                        Price = 15.95,
                        NumPages = 288
                    },

                      new Book
                      {
                          Title = "Deep Work",
                          Author = "Cal Newport",
                          Publisher = "Grand Central Publishing",
                          ISBN = "978-0812981254",
                          ClassCat = "Non-Fiction, Self-Help",
                          Price = 14.99,
                          NumPages = 304
                      },

                        new Book
                        {
                            Title = "It's Your Ship",
                            Author = "Michael Abrashoff",
                            Publisher = "Grand Central Publishing",
                            ISBN = "978-0812981254",
                            ClassCat = "Non-Fiction, Self-Help",
                            Price = 21.66,
                            NumPages =240
                        },

                        new Book
                        {
                            Title = "Sycamore Row",
                            Author = "John Grisham",
                            Publisher = "Bantam",
                            ISBN = "978-0812981254",
                            ClassCat = "Fiction Thrillers",
                            Price = 15.03,
                            NumPages = 400
                        },

                        new Book
                        {
                            Title = "Hunger Games",
                            Author = "Suzanne Collins",
                            Publisher = "Scholastic",
                            ISBN = "978-0812981254",
                            ClassCat = "Fiction Thriller",
                            Price = 20.99,
                            NumPages = 374
                        },

                        new Book
                        {
                            Title = "7 Habits of Highly Effective People",
                            Author = "Stephen Covey",
                            Publisher = "Free Press",
                            ISBN = "978-0812981254",
                            ClassCat = "Self-Help",
                            Price = 15.75,
                            NumPages = 381


                        },

                        new Book
                        {
                            Title = "How To Win Friends and Influence People",
                            Author = "Stephen Covey",
                            Publisher = "Free Press",
                            ISBN = "978-0812981254",
                            ClassCat = "Self-Help",
                            Price = 19.66,
                            NumPages = 291
                        }
                  );
                context.SaveChanges();
            }
        }
    }
}
