using _3_layer_shop.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public Page Page { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductToCategory> ProductToCategories { get; set; }
    }
}
