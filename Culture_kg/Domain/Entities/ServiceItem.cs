using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Culture_kg.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название статьи")]
        [Display(Name = "Название статьи")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание статьи")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание статьи")]
        public override string Text { get; set; }

        [Display(Name = "Категория статьи")]
        public override string ArticleCategory { get; set; }
    }
}
