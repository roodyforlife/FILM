using FILM.Interfaces;
using FILM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public LoginController(IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.userService = userService;
            this.authorisationService = authorisationService;
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if(!authorisationService.IsRegistered(userService, user.Login) || !authorisationService.IsCorrectPassword(userService, user))
            {
                ModelState.AddModelError("Password", "Неправильный логин или пароль");
            }
            if(ModelState.IsValid)
            {
                ControllerContext.HttpContext.Session.SetString("Login", user.Login);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
