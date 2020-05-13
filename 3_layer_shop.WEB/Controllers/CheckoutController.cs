﻿using _3_layer_shop.BLL.Abstract;
using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class CheckoutController : Controller
    {
        private Cart _cart;
        private IDictionary<string, string> _siteSettings;
        private ICommonService _commonService;
        private IBannerService _bannerService;

        public CheckoutController(Cart cart, IBannerService bannerService, ICommonService commonService, IProductService productService)
        {
            _cart = cart;
            _bannerService = bannerService;
            _commonService = commonService;
            _siteSettings = _commonService.GetSiteSettings();
        }

        public ActionResult Checkout()
        {
            if (!_cart.CartLines.Any())
            {
                return RedirectToAction("Cart", "Cart");
            }

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _bannerService.GetBanner(singleBannerId);

                    IMapper bannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = bannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartLineDTO, CartLine>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            IList<CartLine> cartLines = mapper.Map<IList<CartLine>>(_cart.CartLines);

            CheckoutViewModel model = new CheckoutViewModel { CartLines = cartLines, TotalValue = _cart.TotalValue };

            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel checkoutViewModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
