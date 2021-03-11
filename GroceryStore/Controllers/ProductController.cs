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
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int categoryId)
            => View(new ProductListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.Id)
                .Where(p => categoryId == 0 || p.CategoryId == categoryId),
                CurrentCategoryId = categoryId,
            });
    }
}
