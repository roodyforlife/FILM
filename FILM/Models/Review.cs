using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Comment { get; set; }
        public int? FilmId { get; set; }
    }
}
