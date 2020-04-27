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
                    new ProductPageDTO{ MainImage = new ImageDTO { Path = "/images/product_1.jpg", Alt = "product_1" }, Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 },
                    new ProductPageDTO{ MainImage = new ImageDTO { Path = "/images/product_2.jpg", Alt = "product_2" }, Name = "Product2", Alias = "product_2", Price = 423 },
                    new ProductPageDTO{ MainImage = new ImageDTO { Path = "/images/product_3.jpg", Alt = "product_3" }, Name = "Product3", Alias = "product_3", Price = 112, DiscountPrice = 54 }
                },
                MainImage = new ImageDTO { Path = "/images/product_5.jpg", Alt = "product_5" },
                Name = "Product5",
                Alias = "product_5",
                Price = 2344,
                DiscountPrice = 444,
                Images = new List<ImageDTO> 
                {
                    new ImageDTO { Path = "/images/product_1.jpg", Alt = "product_1" },
                    new ImageDTO { Path = "/images/product_2.jpg", Alt = "product_2" },
                    new ImageDTO { Path = "/images/product_3.jpg", Alt = "product_3" },
                    new ImageDTO { Path = "/images/product_4.jpg", Alt = "product_4" }
                },
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
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_1.jpg", Alt = "product_1" }, Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_2.jpg", Alt = "product_2" }, Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_3.jpg", Alt = "product_3" }, Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_4.jpg", Alt = "product_4" }, Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_5.jpg", Alt = "product_5" }, Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_6.jpg", Alt = "product_6" }, Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_7.jpg", Alt = "product_7" }, Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_8.jpg", Alt = "product_8" }, Name = "Product8", Alias = "product_8", Price = 111 });

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
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_1.jpg", Alt = "product_1" }, Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_2.jpg", Alt = "product_2" }, Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_3.jpg", Alt = "product_3" }, Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_4.jpg", Alt = "product_4" }, Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_5.jpg", Alt = "product_5" }, Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_6.jpg", Alt = "product_6" }, Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_7.jpg", Alt = "product_7" }, Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_8.jpg", Alt = "product_8" }, Name = "Product8", Alias = "product_8", Price = 111 });

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
