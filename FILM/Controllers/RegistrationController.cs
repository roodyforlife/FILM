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
    public class RegistrationController : Controller
    {
        private readonly IDbUserService userService;
        private readonly IAuthorisationService authorisationService;
        public RegistrationController(IDbUserService userService, IAuthorisationService authorisationService)
        {
            this.userService = userService;
            this.authorisationService = authorisationService;
        }
        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if(user.Login is not null && authorisationService.IsRegistered(userService, user.Login))
            {
                ModelState.AddModelError("Login", "Такой аккаунт уже существует");
            }
            if (user.Name is null)
                ModelState.AddModelError("Name", "Это обязательное поле");
            if(ModelState.IsValid)
            {
                user.IsAdmin = false;
                userService.Add(user);
                ControllerContext.HttpContext.Session.SetString("Login", user.Login);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
