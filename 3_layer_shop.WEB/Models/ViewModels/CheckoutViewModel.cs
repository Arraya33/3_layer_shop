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

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a address")]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a email")]
        public string Email { get; set; }
    }
}
