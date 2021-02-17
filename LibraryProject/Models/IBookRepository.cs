using System;
using System.Linq;

namespace LibraryProject.Models
{
    public interface IBookRepository
    {
       IQueryable<Book> Books { get; }
    }
}
