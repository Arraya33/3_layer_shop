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
        public ProductDTO GetProduct(string productAlias)
        {
            ProductDTO product = new ProductDTO
            {
                RelatedProducts = new List<ProductDTO>
                {
                    new ProductDTO{ MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 },
                    new ProductDTO{ MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 423 },
                    new ProductDTO{ MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 112, DiscountPrice = 54 }
                },
                MainImage = "/images/product_5.jpg",
                Name = "Product5",
                Alias = "product_5",
                Price = 2344,
                DiscountPrice = 444,
                Images = new List<string> { "/images/product_1.jpg", "/images/product_2.jpg", "/images/product_3.jpg", "/images/product_4.jpg" },
                Quantity = 4,
                IntroText = "<p>Text text text</p>",
                Description = "<p>Text2 text2 text2</p>"
            };

            return product;
        }

        public ProductCategoryDTO GetProductCategory(string categoryAlias, int pageNumber, int pageSize)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            products.Add(new ProductDTO { MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductDTO { MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductDTO { MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductDTO { MainImage = "/images/product_4.jpg", Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductDTO { MainImage = "/images/product_5.jpg", Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductDTO { MainImage = "/images/product_6.jpg", Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductDTO { MainImage = "/images/product_7.jpg", Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductDTO { MainImage = "/images/product_8.jpg", Name = "Product8", Alias = "product_8", Price = 111 });

            ProductCategoryDTO productCategory = new ProductCategoryDTO { Name = "Категория товаров", 
                Products = products.Skip((pageNumber - 1) * pageSize).Take(pageSize), 
                TotalItems = products.Count };

            return productCategory;
        }
    }
}
