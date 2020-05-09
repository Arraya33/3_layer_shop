using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartLine> CartLines { get; set; }
    }
}
