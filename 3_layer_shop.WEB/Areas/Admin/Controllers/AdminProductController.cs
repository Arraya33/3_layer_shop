using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Areas.Admin.Models.ViewModels;
using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
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
        private IProductService _productService;
        int _pageSize;

        public AdminProductController(IProductService productService)
        {
            _productService = productService;
            _pageSize = 3;
        }

        public IActionResult ProductCategoriesList(int page = 1)
        {
            ProductCategoriesListDTO productCategoriesDTOs = _productService.GetProductCategoryList(page, _pageSize);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoriesListDTO, ProductCategoriesListViewModel>();
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
            }).CreateMapper();
            ProductCategoriesListViewModel productCateories = mapper.Map<ProductCategoriesListViewModel>(productCategoriesDTOs);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoriesDTOs.TotalItems,
                PageAction = "ProductCategoriesList"
            };

            productCateories.PagingInfo = pagingInfo;

            return View(productCateories);
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

        [HttpPost]
        public IActionResult DeleteProductCategory(int categoryId)
        {
            ProductListPageViewModel productListPageViewModel = new ProductListPageViewModel();
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

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            ProductPageViewModel productPageViewModel = new ProductPageViewModel();
            return View(productPageViewModel);
        }

        public ViewResult Create() 
            => View("EditProductCategory", new ProductListPageViewModel());
    }
}
