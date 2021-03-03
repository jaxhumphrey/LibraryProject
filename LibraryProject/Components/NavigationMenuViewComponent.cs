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

        //Builds repository based off of IBookRepository.cs
        private IBookRepository repository;

        public NavigationMenuViewComponent (IBookRepository b)
        {
            //set repository made ^ and set it equal to b
            repository = b;
        }

        //automatically called when ViewComponent is added to screen
        public IViewComponentResult Invoke() 

            
        {
            //Allows us to Highlight cateory page we clock on
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //queries and gets data from the repository, selects certain ones, makes sure they are unique and then orders by them
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
