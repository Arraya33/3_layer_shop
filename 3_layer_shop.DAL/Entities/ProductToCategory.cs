using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class ProductToCategory
    {
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
