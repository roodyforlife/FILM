using FILM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Interfaces
{
    public interface IApplicationService
    {
        public void Add(Film film);
        public List<Film> GetAll();
        public Film GetSome(int filmId);
        public void Del(Film film);
    }
}
