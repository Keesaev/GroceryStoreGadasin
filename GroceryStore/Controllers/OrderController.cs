using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class OrderController : Controller
    {
        private IGroceryRepository repository;
        private CurrentCart cart;
        public OrderController(IGroceryRepository repoServise, CurrentCart cartService)
        {
            repository = repoServise;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
                return View(order);
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
