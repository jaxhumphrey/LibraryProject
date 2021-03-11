using System;
using System.Linq;

namespace LibraryProject.Models
{
    public interface IBookRepository
    {
        //gets data from database
       IQueryable<Book> Books { get; }
    }
}
