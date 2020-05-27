using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminProductController : Controller
    {
        public IActionResult ProductCategoriesList()
        {
            IEnumerable<ProductListPageViewModel> productListPageViewModels = new List<ProductListPageViewModel>();
            return View(productListPageViewModels);
        }

        public IActionResult ProductsList()
        {
            IEnumerable<ProductPageViewModel> productPageViewModels = new List<ProductPageViewModel>();
            return View(productPageViewModels);
        }

        public IActionResult EditProductCategory(int categoryId)
        {
            ProductListPageViewModel productListPageViewModel = new ProductListPageViewModel();
            return View(productListPageViewModel);
        }

        [HttpPost]
        public IActionResult EditProductCategory(ProductListPageViewModel productListPageViewModel)
        {
            return View(productListPageViewModel);
        }

        public IActionResult EditProduct(int productId)
        {
            ProductPageViewModel productPageViewModel = new ProductPageViewModel();
            return View(productPageViewModel);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductPageViewModel productPageViewModel)
        {
            return View(productPageViewModel);
        }
    }
}
