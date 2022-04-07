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
    public class ReviewController : Controller
    {
        private readonly IApplicationService applicationService;
        public ReviewController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        [HttpGet]
        public ViewResult Review(int review)
        {
            ViewBag.Test = ControllerContext.HttpContext.Session.GetString("Login");
            ViewBag.FilmsBase = applicationService.GetSome(review);
            return View();
        }
        [HttpPost]
        public IActionResult Review(Review review)
        {
            if (ModelState.IsValid)
                applicationService.AddComment(review);
            return RedirectPermanent($"../Review/Review?review={review.FilmId}");
        }
    }
}
