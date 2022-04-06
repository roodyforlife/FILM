using FILM.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IDbUserService userService;
        public ProfileController(IDbUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Profile()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Login");
            if (user is null)
            {
                return RedirectPermanent("../Login/Login");
            }
            ViewBag.UserBase = userService.Get(user);
            return View();
        }
        public IActionResult Ex()
        {
            ControllerContext.HttpContext.Session.Remove("Login");
            return RedirectPermanent("../Home/Index");
        }
    }
}
