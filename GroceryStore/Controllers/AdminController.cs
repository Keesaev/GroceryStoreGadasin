using GroceryStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IGroceryRepository repository;
        public AdminController(IGroceryRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() => View(repository.Products);
        public ViewResult Edit(int Id) =>
            View(repository.Products
                .FirstOrDefault(p => p.Id == Id));
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Продукт {product.Name} успешно сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create() => View("Edit", new Product());
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Product deletedProduct = repository.DeleteProduct(Id);
            if(deletedProduct != null)
            {
                TempData["message"] = $"Продукт {deletedProduct.Name} успешно удалён";
            }
            return RedirectToAction("Index");
        }
    }
}
