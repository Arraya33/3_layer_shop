using _3_layer_shop.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class ProductPageDTO : PageDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string IntroText { get; set; }
        public string MainImage { get; set; }
        public IEnumerable<string> Images { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductPageDTO> RelatedProducts { get; set; }
    }
}
