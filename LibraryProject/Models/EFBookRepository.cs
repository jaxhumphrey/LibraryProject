using System;
using System.Linq;

namespace LibraryProject.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDBContext _context;

        //Constructor           Pulls
        public EFBookRepository(BookDBContext context)
        {
            //context of BookDBContext to EFBookRepository _context
            _context = context;
        }

         //Function that returns all books from _context.
        public IQueryable<Book> Books => _context.Books;
    }
}
