using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Infrastructure;
using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages
{
    public class ShopModel : PageModel
    {
        //instance of repository
        private IBookRepository repository;

        //Constructor
       public ShopModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        
        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long bookid, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(p => p.BookId == bookid);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookid, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.BookId == bookid).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}
