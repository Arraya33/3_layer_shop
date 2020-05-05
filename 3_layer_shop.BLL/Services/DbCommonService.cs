using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbCommonService : ICommonService
    {
        public HomePageDTO GetHomePage()
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

            HomePageDTO homePage = new HomePageDTO { Products = products, Title = "Главная" };

            return homePage;
        }
    }
}
