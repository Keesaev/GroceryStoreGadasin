using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
