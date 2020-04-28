using _3_layer_shop.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Page Page { get; set; }
        public IEnumerable<ProductToCategory> ProductToCategories { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string IntroText { get; set; }
        public Image MainImage { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductToProduct> ProductToProductsParents { get; set; }
        public IEnumerable<ProductToProduct> ProductToProductsChilds { get; set; }
    }
}
