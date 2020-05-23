using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Areas.Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо повторить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль*")]
        public string PasswordConfirm { get; set; }
    }
}
