using System;
using System.Linq;

namespace LibraryProject.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDBContext _context;

        //Constructor
        public EFBookRepository(BookDBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
