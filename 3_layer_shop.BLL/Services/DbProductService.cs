using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbProductService : IProductService
    {
        public ProductPageDTO GetProductPage(string productAlias)
        {
            ProductPageDTO product = new ProductPageDTO
            {
                RelatedProducts = new List<ProductPageDTO>
                {
                    new ProductPageDTO{ MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 },
                    new ProductPageDTO{ MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 423 },
                    new ProductPageDTO{ MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 112, DiscountPrice = 54 }
                },
                MainImage = "/images/product_5.jpg",
                Name = "Product5",
                Alias = "product_5",
                Price = 2344,
                DiscountPrice = 444,
                Images = new List<string> { "/images/product_1.jpg", "/images/product_2.jpg", "/images/product_3.jpg", "/images/product_4.jpg" },
                Quantity = 4,
                IntroText = "<p>Text text text</p>",
                Description = "<p>Text2 text2 text2</p>",
                Title = "Product 5"
            };

            return product;
        }

        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize)
        {
            List<ProductPageDTO> products = new List<ProductPageDTO>();
            products.Add(new ProductPageDTO { MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_4.jpg", Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_5.jpg", Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_6.jpg", Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_7.jpg", Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_8.jpg", Name = "Product8", Alias = "product_8", Price = 111 });

            ProductCategoryPageDTO productCategory = new ProductCategoryPageDTO 
            { 
                Name = "Категория товаров", 
                Products = products.Skip((pageNumber - 1) * pageSize).Take(pageSize), 
                TotalItems = products.Count,
                Title = "Категория товаров"
            };

            return productCategory;
        }

        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize)
        {
            List<ProductPageDTO> products = new List<ProductPageDTO>();
            products.Add(new ProductPageDTO { MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_4.jpg", Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_5.jpg", Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_6.jpg", Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_7.jpg", Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_8.jpg", Name = "Product8", Alias = "product_8", Price = 111 });

            ProductCategoryPageDTO productCategory = new ProductCategoryPageDTO
            {
                Products = products.Skip((pageNumber - 1) * pageSize).Take(pageSize),
                TotalItems = products.Count
            };

            return productCategory;
        }

        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList()
        {
            List<ProductCategoryPageDTO> productCategoryList = new List<ProductCategoryPageDTO>();
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 1", Alias = "Category1" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 2", Alias = "Category2" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 55", Alias = "Category55" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 4", Alias = "Category4" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 5", Alias = "Category5" });

            return productCategoryList;
        }
    }
}
