using _3_layer_shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IProductService
    {
        public ProductPageDTO GetProductPage(string productAlias);
        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize);
        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize);
        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList();
    }
}
