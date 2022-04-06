using FILM.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Controllers
{
    public class WatchController : Controller
    {
        private readonly IApplicationService applicationService;
        public WatchController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        public IActionResult Watch(int filmId)
        {
            var film = applicationService.GetSome(filmId);
            return View(film);
        }
    }
}
