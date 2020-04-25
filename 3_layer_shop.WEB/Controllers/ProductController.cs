using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
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
        readonly IProductService _productService;
        readonly IConfiguration _configuration;
        int _pageSize;

        public ProductController(IConfiguration configuration, IProductService productService)
        {
            _configuration = configuration;
            _productService = productService;
            _pageSize = _configuration.GetValue<int>("PageSize");
        }

        public ActionResult Product(string productAlias)
        {
            ProductDTO productDTO = _productService.GetProduct(productAlias);
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            ProductViewModel model = mapper.Map<ProductViewModel>(productDTO);

            ViewBag.Title = model.Name;

            return View(model);
        }

        public ActionResult List(string categoryAlias, int page = 1)
        {
            ProductCategoryDTO productCategoryDTO = _productService.GetProductCategory(categoryAlias, page, _pageSize);

            IMapper mapper = new MapperConfiguration(cfg => 
            { 
                cfg.CreateMap<ProductCategoryDTO, ProductListViewModel>(); 
                cfg.CreateMap<ProductDTO, ProductViewModel>(); 
            }).CreateMapper();
            ProductListViewModel model = mapper.Map<ProductListViewModel>(productCategoryDTO);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoryDTO.TotalItems
            };

            model.PagingInfo = pagingInfo;

            ViewBag.Title = model.Name;

            return View(model);
        }

        public ActionResult DiscountList(int page = 1)
        {
            ProductCategoryDTO productCategoryDTO = _productService.GetDiscountProducts(page, _pageSize);

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoryDTO, ProductListViewModel>();
                cfg.CreateMap<ProductDTO, ProductViewModel>();
            }).CreateMapper();
            ProductListViewModel model = mapper.Map<ProductListViewModel>(productCategoryDTO);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page, 
                ItemsPerPage = _pageSize, 
                TotalItems = productCategoryDTO.TotalItems
            };

            model.PagingInfo = pagingInfo;
            model.Name = "Товары со скидкой";
            ViewBag.Title = "Товары со скидкой";

            return View(model);
        }
    }
}
