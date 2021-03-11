using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceryStore.Models;
using GroceryStore.Models.ViewModels;

namespace GroceryStore.Controllers
{
    public class ProductController : Controller
    {
        private IGroceryRepository repository;
        public ProductController(IGroceryRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string categoryName)
            => View(new ProductListViewModel
            {
                
                Products = repository.Products
                .OrderBy(p => p.Id)
                .Where(p => categoryName == null ||
                    p.CategoryId == (repository.Categories.Single(c=>c.Name == categoryName)).Id),
                CurrentCategoryName = categoryName,
            });
    }
}
