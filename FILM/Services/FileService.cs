using FILM.Interfaces;
using FILM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Services
{
    public class FileService : IFileService
    {
        IWebHostEnvironment appEnvironment;
        public FileService(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }
        public string GetFilePath(Film film, IFormFile uploadedFile)
        {
            var folder = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Files/{film.Title}_{film.Year}_{film.Country}"));
                string path = $"/Files/{film.Title}_{film.Year}_{film.Country}/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using ( var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                return path;

        }
    }
}
