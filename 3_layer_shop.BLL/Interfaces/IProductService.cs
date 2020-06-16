using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Возвращает страницу товаров, содержащих в наименовании searchKey
        /// </summary>
        /// <param name="searchKey">ключ для поиска товаров</param>
        /// <returns></returns>
        public ProductCategoryPageDTO GetSearcedProducts(string searchKey);

        /// <summary>
        /// возвращает полную версию страницы товара по его ЧПУ
        /// </summary>
        /// <param name="productAlias">ЧПУ искомого товара</param>
        /// <returns></returns>
        public ProductPageDTO GetProduct(string productAlias);

        /// <summary>
        /// возвращает сокращенную версию страницы товара по его Id
        /// </summary>
        /// <param name="productId">Id искомого товара</param>
        /// <returns></returns>
        public ProductPageDTO GetProduct(int productId);

        /// <summary>
        /// возвращает полную версию страницы категории товара по ее ЧПУ
        /// </summary>
        /// <param name="categoryAlias">ЧПУ искомой категории</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество элементов на странице</param>
        /// <param name="orderType">поле по которому происходит упорядочивание</param>
        /// <returns></returns>
        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize, ProductOrderType orderType);

        /// <summary>
        /// возвращает сокращенную версию страницы категории товара по ее Id
        /// </summary>
        /// <param name="categoryId">Id искомой категории</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество элементов на странице</param>
        /// <param name="orderType">поле по которому происходит упорядочивание</param>
        /// <returns></returns>
        public ProductCategoryPageDTO GetProductCategoryPage(int categoryId, int pageNumber, int pageSize, ProductOrderType orderType);

        /// <summary>
        /// возвращает страницу с товарами по скидке
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество элементов на странице</param>
        /// <param name="orderType">поле по которому происходит упорядочивание</param>
        /// <returns></returns>
        public ProductCategoryPageDTO GetDiscountProductsPage(int pageNumber, int pageSize, ProductOrderType orderType);

        /// <summary>
        /// возвращает полный список категорий товаров
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList();

        /// <summary>
        /// возвращает страницу со списком категорий товаров
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество элементов на странице</param>
        /// <returns></returns>
        public ProductCategoriesListDTO GetProductCategoryList(int pageNumber, int pageSize);

        /// <summary>
        /// возвращает полный спискок товаров
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductPageDTO> GetProductList();

        /// <summary>
        /// возвращает страницу со списком товаров
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество элементов на странице</param>
        /// <returns></returns>
        public ProductCategoryPageDTO GetProductList(int pageNumber, int pageSize);

        /// <summary>
        /// изменяет существующий либо, при отсутствии, добавляет новый товар
        /// </summary>
        /// <param name="productPage">редактируемый товар</param>
        public void EditProductPage(ProductPageDTO productPage);

        /// <summary>
        /// удаляет существующий товар
        /// </summary>
        /// <param name="productId">Id товара</param>
        public ProductPageDTO DeleteProductPage(int productId);

        /// <summary>
        /// удаляет существующую категорию товаров
        /// </summary>
        /// <param name="categoryId">Id категории товара</param>
        /// <returns></returns>
        public ProductCategoryPageDTO DeleteProductCategoryPage(int categoryId);

        public void EditProductCategoryPage(ProductCategoryPageDTO productCategoryPage);
    }
}
