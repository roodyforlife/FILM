using FILM.Interfaces;
using FILM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.IO;
using Microsoft.EntityFrameworkCore;

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

        public void AddComment(Review review)
        {
            db.Reviews.Add(review);
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
            return db.Films.Include(x => x.Reviews).FirstOrDefault(x => x.Id == filmId);
        }

        public List<Film> GetSomeBySearch(Search search)
        {
            search.Title = search.Title ?? "";
            return db.Films.Include(x => x.Reviews).ToList().FindAll(x => x.Type.Contains(search.Type) && x.Genre.Contains(search.Genre) && x.Country.Contains(search.Country) && x.Title.Contains(search.Title) && x.Year.Contains(search.Year));
        }
    }
}
