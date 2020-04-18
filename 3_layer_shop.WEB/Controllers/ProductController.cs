using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class ProductController : Controller
    {
        readonly IConfiguration _configuration;
        int _pageSize;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _pageSize = _configuration.GetValue<int>("PageSize");
        }

        public ActionResult Product(string productAlias)
        {
            return View();
        }

        public ActionResult List(string categoryAlias)
        {
            return View();
        }

        public ActionResult DiscountList(int page = 1)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            products.Add(new ProductViewModel { MainImage = "/images/product_1.jpg", Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductViewModel { MainImage = "/images/product_2.jpg", Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductViewModel { MainImage = "/images/product_3.jpg", Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductViewModel { MainImage = "/images/product_4.jpg", Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductViewModel { MainImage = "/images/product_5.jpg", Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductViewModel { MainImage = "/images/product_6.jpg", Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductViewModel { MainImage = "/images/product_7.jpg", Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductViewModel { MainImage = "/images/product_8.jpg", Name = "Product8", Alias = "product_8", Price = 111 });

            PagingInfo pagingInfo = new PagingInfo 
            {
                CurrentPage = page, 
                ItemsPerPage = _pageSize, 
                TotalItems = products.Count 
            };

            ProductListViewModel model = new ProductListViewModel 
            { 
                Products = products.Skip((page - 1) * _pageSize).Take(_pageSize),
                PagingInfo = pagingInfo,
                Name = "Товары со скидкой"
            };

            return View(model);
        }
    }
}
