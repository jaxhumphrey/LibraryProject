using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        // declared Iquerable list of books IBookRepository.cs
        private IBookRepository repository;

        public NavigationMenuViewComponent (IBookRepository b)
        {
            //set repository made ^ and set it equal to b
            repository = b;
        }

        //automatically called when ViewComponent is added to screen
        public IViewComponentResult Invoke() 
            
        {
            //pulls data called "category" from url and puts it into the viewbag
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //queries and gets data from the repository, selects certain ones, makes sure they are unique, then orders by them sends to "default page"
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
