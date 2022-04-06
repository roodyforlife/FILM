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
    public class CreateController : Controller
    {
        private readonly IFileService fileService;
        private readonly IApplicationService applicationService;
        public CreateController(IFileService fileService, IApplicationService applicationService)
        {
            this.fileService = fileService;
            this.applicationService = applicationService;
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile upload_photo, IFormFile upload_video, Film film)
        {
            if(ModelState.IsValid && upload_photo is not null && upload_video is not null)
            {
                film.PhotoPath = fileService.GetFilePath(film, upload_photo);
                film.VideoPath = fileService.GetFilePath(film, upload_video);
                applicationService.Add(film);
                return RedirectPermanent("../Home/Index");
            }
            ViewBag.IsPhotoFileValid = upload_photo is null ? "field-validation-file-error" : "";
            ViewBag.IsVideoFileValid = upload_video is null ? "field-validation-file-error" : "";
            return View();
        }
    }
}
