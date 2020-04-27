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
            products.Add(new ProductPageDTO { MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_4.jpg", Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_5.jpg", Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_6.jpg", Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_7.jpg", Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = "/images/product_8.jpg", Name = "Product8", Alias = "product_8", Price = 111 });

            HomePageDTO homePage = new HomePageDTO { Products = products, BannerGroupId = 3, Title = "Главная" };

            return homePage;
        }
    }
}
