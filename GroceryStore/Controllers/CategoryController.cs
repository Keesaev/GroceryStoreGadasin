using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    public class CategoryController : Controller
    {
        private IGroceryRepository repository;
        public CategoryController(IGroceryRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int categoryId)
            => View(repository.Categories
                .OrderBy(c => c.Id)
            );
    }
}
