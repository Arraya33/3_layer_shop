using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public IList<CartLine> CartLines { get; set; }

        public int TotalValue { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        [Display(Name = "Адрес*")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [Display(Name = "E-mail*")]
        public string Email { get; set; }
    }
}
