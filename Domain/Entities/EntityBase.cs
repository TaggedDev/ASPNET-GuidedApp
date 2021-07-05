using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    /// <summary>
    /// Base abstract class for any entity
    /// </summary>
    public abstract class EntityBase
    {
        // CreationDate will create a timestamp with current time when the entity is created
        protected EntityBase() => CreationDate = DateTime.UtcNow;

        // Primary Key => Required
        [Required]
        public Guid Id { get; set; }

        [Display(Name ="Название (заголовок)")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO Title метатэг")]
        public string MetaTitle{ get; set; }

        [Display(Name = "SEO Description метатэг")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO Keywords  метатэг")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime CreationDate { get; set; }
    }
}
