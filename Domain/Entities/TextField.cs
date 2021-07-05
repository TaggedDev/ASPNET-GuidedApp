using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class TextField : EntityBase
    {
        // A word for adminpanel
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public override string Text { get; set; } = "Содержание страницы заполняется администратором.";

    }
}
