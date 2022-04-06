using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FILM.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public string VideoPath { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string About { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Plot { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Genre { get; set; }


    }
}
