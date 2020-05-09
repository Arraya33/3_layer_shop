using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class ProductToProduct
    {
        public Product ProductParent { get; set; }
        public Product ProductChild { get; set; }
        public int ProductChildId { get; set; }
        public int ProductParentId { get; set; }
    }
}
