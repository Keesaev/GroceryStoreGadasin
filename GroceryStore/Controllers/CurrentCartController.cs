using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using GroceryStore.Infrastructure;
using GroceryStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GroceryStore.Controllers
{   [Authorize]
    public class CurrentCartController : Controller
    {
        private IGroceryRepository repository;
        public CurrentCartController(IGroceryRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CurrentCartIndexViewModel
            {
                CurrentCart = GetCurrentCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCurrentCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == productId);
            if(product != null)
            {
                CurrentCart currentCart = GetCurrentCart();
                currentCart.AddItem(product, 1);
                SaveCurrentCart(currentCart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCurrentCart(int productId,
            string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                CurrentCart currentCart = GetCurrentCart();
                currentCart.RemoveLine(product);
                SaveCurrentCart(currentCart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private CurrentCart GetCurrentCart()
        {
            CurrentCart currentCart = HttpContext.Session.GetJson<CurrentCart>("CurrentCart") ?? new CurrentCart();
            return currentCart;
        }

        private void SaveCurrentCart(CurrentCart currentCart)
        {
            HttpContext.Session.SetJson("CurrentCart", currentCart);
        }
    }
}
