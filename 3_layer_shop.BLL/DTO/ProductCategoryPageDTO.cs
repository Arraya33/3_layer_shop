using _3_layer_shop.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class ProductCategoryPageDTO : PageDTO
    {
        public string Name { get; set; }
        public IEnumerable<ProductPageDTO> Products { get; set; }
        public int TotalItems { get; set; }
    }
}
