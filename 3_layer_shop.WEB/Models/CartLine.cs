using _3_layer_shop.WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models
{
    public class CartLine
    {
        public ProductPageViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
