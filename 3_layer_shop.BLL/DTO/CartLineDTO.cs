using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class CartLineDTO
    {
        public ProductPageDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
