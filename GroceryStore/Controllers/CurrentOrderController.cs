using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class CurrentOrderController : Controller
    {
        public ViewResult Checkout() => View(new CurrentOrder());
    }
}
