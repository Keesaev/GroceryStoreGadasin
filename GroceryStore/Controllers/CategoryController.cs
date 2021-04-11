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

        public ViewResult List(int category)
            => View(repository.Products
                .OrderBy(c => c)
                .Select(p => p.Category)
                .Distinct()
            );
    }
}
