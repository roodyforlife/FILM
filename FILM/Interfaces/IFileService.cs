using FILM.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Interfaces
{
    public interface IFileService
    {
        public string GetFilePath(Film film, IFormFile uploadedFile);
    }
}
