using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Автор")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 50 символов")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0, 2014, ErrorMessage = "Недопустимый год")]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [Range(1, 5000, ErrorMessage = "Недопустимое число страниц")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Число страниц")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}