using FILM.Interfaces;
using FILM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationContext db;
        public ApplicationService(ApplicationContext db)
        {
            this.db = db;
        }
        public void Add(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }

        public void Del(Film film)
        {
            db.Films.Remove(film);
            db.SaveChanges();
        }

        public List<Film> GetAll()
        {
            return db.Films.ToList();
        }

        public Film GetSome(int filmId)
        {
            return db.Films.FirstOrDefault(x => x.Id == filmId);
        }
    }
}
