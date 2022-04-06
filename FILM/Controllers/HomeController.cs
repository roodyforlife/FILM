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
        public IActionResult Index(Search search, string searchType, string searchNew)
        {
            search.Type = searchType ?? search.Type;
            search.Year = searchNew ?? search.Year;
            var user = ControllerContext.HttpContext.Session.GetString("Login");
            ViewBag.IsAdmin = user is null ? false : userService.Get(user).IsAdmin;
            ViewBag.FilmsBase = applicationService.GetSomeBySearch(search);
            return View();
        }
        public IActionResult Delet(int filmIdDelete)
        {
            applicationService.Del(applicationService.GetSome(filmIdDelete));
            return RedirectPermanent("../Home/Index");
        }
    }

}
