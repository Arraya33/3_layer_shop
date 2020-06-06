using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IProductService
    {
        public ProductCategoryPageDTO GetSearcedProducts(string searchKey);
        public ProductPageDTO GetProduct(string productAlias);
        public ProductPageDTO GetProduct(int productId);
        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize, ProductOrderType orderType);
        public ProductCategoryPageDTO GetProductCategoryPage(int categoryId, int pageNumber, int pageSize, ProductOrderType orderType);
        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize, ProductOrderType orderType);
        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList();
        public ProductCategoriesListDTO GetProductCategoryList(int pageNumber, int pageSize);
        public IEnumerable<ProductPageDTO> GetProductList();
        public ProductCategoryPageDTO GetProductList(int pageNumber, int pageSize);
    }
}
