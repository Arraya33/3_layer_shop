using _3_layer_shop.BLL.DTO;
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
        private ICommonService _commonService;
        private IProductService _productService;
        private IConfiguration _configuration;
        private IImageService _imageService;
        private IDictionary<string, string> _siteSettings;
        int _pageSize;

        public ProductController(IConfiguration configuration, IProductService productService, ICommonService commonService, IImageService imageService)
        {
            _configuration = configuration;
            _productService = productService;
            _commonService = commonService;
            _imageService = imageService;
            _pageSize = _configuration.GetValue<int>("PageSize");
            _siteSettings = _commonService.GetSiteSettings();
        }

        public ActionResult Product(string productAlias)
        {
            ProductPageDTO productPageDTO = _productService.GetProduct(productAlias);

            if (productPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductPageViewModel model = mapper.Map<ProductPageViewModel>(productPageDTO);

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _imageService.GetBanner(singleBannerId);

                    IMapper bannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = bannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

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

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _imageService.GetBanner(singleBannerId);

                    IMapper bannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = bannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

            model.PagingInfo = pagingInfo;
            ViewBag.Title = model.Title;

            return View(model);
        }

        public ActionResult Search(string search)
        {
            ProductCategoryPageDTO productCategoryPageDTO = _productService.GetSearcedProducts(search);

            if (productCategoryPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductListPageViewModel model = mapper.Map<ProductListPageViewModel>(productCategoryPageDTO);

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _imageService.GetBanner(singleBannerId);

                    IMapper bannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = bannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

            ViewBag.Title = model.Title;
            return View("List", model);
        }

        public ActionResult DiscountList(int page = 1)
        {
            ProductCategoryPageDTO discountProductsPageDTO = _productService.GetDiscountProductsPage(page, _pageSize, ProductOrderType.Name);

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

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _imageService.GetBanner(singleBannerId);

                    IMapper BannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = BannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

            model.PagingInfo = pagingInfo;
            ViewBag.Title = model.Title;

            return View("List", model);
        }
    }
}
