using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IGroceryRepository repository;
        public NavigationMenuViewComponent(IGroceryRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Categories
                .OrderBy(x => x)
                .Select(x => x.Name));
        }
    }
}
