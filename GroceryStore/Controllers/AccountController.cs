using GroceryStore.Models;
using GroceryStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    public class AccountController : Controller
    {
        private IGroceryRepository repository;

        public AccountController(IGroceryRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await repository.Users
                    .FirstOrDefaultAsync(u => u.Login == model.Login);
                if(user == null)
                {
                    user = new User { Login = model.Login, Password = model.Password, Role = "user" };
                    repository.SaveUser(user);
                    await Authenticate(user);
                }
                return Redirect("/");
            }
            else
                ModelState.AddModelError("", "Некорректные логин или пароль");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await repository.Users
                    .FirstOrDefaultAsync(u => u.Login == loginModel.Login 
                    && u.Password == loginModel.Password);
                if(user != null)
                {
                    await Authenticate(user);
                    if (user.Role == "admin")
                        return Redirect("/Admin/Index");
                    else
                        return Redirect("/");
                }
            }
            ModelState.AddModelError("", "Неверный логин или пароль");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await HttpContext.SignOutAsync("Cookies");
            return Redirect(returnUrl);
        }

        public async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
