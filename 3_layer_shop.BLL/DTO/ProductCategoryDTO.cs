using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public int TotalItems { get; set; }
    }
}
