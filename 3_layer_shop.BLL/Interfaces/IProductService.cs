﻿using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IProductService
    {
        public ProductPageDTO GetProductPage(string productAlias);
        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize, ProductOrderType orderType);
        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize, ProductOrderType orderType);
        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList();
    }
}
