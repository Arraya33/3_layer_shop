using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class ProductCategoriesListDTO
    {
        public IEnumerable<ProductCategoryPageDTO> ProductCategories { get; set; }
        public int TotalItems { get; set; }
    }
}
