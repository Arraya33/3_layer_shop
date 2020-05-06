﻿using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
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
            ProductPageDTO productPageDTO = _productService.GetProductPage(productAlias);

            if (productPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductPageViewModel model = mapper.Map<ProductPageViewModel>(productPageDTO);

            ViewBag.Title = model.Title;

            return View(model);
        }

        public ActionResult List(string categoryAlias, int page = 1)
        {
            ProductCategoryPageDTO productCategoryPageDTO = _productService.GetProductCategoryPage(categoryAlias, page, _pageSize, ProductOrderType.Name);

            if (productCategoryPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg => 
            { 
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductListPageViewModel model = mapper.Map<ProductListPageViewModel>(productCategoryPageDTO);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoryPageDTO.TotalItems,
                PageAction = "List"
            };

            model.PagingInfo = pagingInfo;
            ViewBag.Title = model.Title;

            return View(model);
        }

        public ActionResult DiscountList(int page = 1)
        {
            ProductCategoryPageDTO discountProductsPageDTO = _productService.GetDiscountProductPage(page, _pageSize, ProductOrderType.Name);

            if (discountProductsPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductListPageViewModel model = mapper.Map<ProductListPageViewModel>(discountProductsPageDTO);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page, 
                ItemsPerPage = _pageSize, 
                TotalItems = discountProductsPageDTO.TotalItems,
                PageAction = "DiscountList"
            };

            model.PagingInfo = pagingInfo;
            ViewBag.Title = model.Title;

            return View("List", model);
        }
    }
}
