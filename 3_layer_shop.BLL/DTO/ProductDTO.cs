using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string IntroText { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public IEnumerable<string> Images { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductDTO> RelatedProducts { get; set; }
    }
}
