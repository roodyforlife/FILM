using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FILM.Annotations;
using System.Web.Mvc;

namespace FILM.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        /*[Required(ErrorMessage = "Это обязательное поле")]*/
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина имени может быть от 3 до 20 символов")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "В пароле могут быть только латинские символы")]
        [IsSpace(ErrorMessage = "В пароле не должно быть пробелов")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Довжина пароля має бути від 6 до 20 символів")]
        public string Password { get; set; }
        [RegularExpression(@"[A-Za-z0-9_]+", ErrorMessage = "В логине могут быть только латинские символы и знак '_'")]
        [IsSpace(ErrorMessage = "В логине не должно быть пробелов")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Длина логина может быть от 1 до 12 символов")]
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
    }
}
