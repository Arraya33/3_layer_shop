using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels.Abstract
{
    public abstract class PageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ЧПУ")]
        [Display(Name = "ЧПУ*")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "Введите Title")]
        [Display(Name = "Title*")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
