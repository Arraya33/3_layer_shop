using _3_layer_shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IProductService
    {
        public ProductDTO GetProduct(string productAlias);
        public ProductCategoryDTO GetProductCategory(string categoryAlias, int pageNumber, int pageSize);
    }
}
