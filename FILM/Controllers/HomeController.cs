using FILM.Interfaces;
using FILM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationService applicationService;
        private readonly IDbUserService userService;
        public HomeController(IApplicationService applicationService, IDbUserService userService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Login");
            ViewBag.IsAdmin = user is null ? false : userService.Get(user).IsAdmin;
            List<Film> films = new();
            films = applicationService.GetAll(); 
            return View(films);
        }
        public IActionResult Del(int filmIdDelete)
        {
            applicationService.Del(applicationService.GetSome(filmIdDelete));
            return RedirectPermanent("../Home/Index");
        }
    }

}
