using _3_layer_shop.BLL.Abstract;
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
    public class CartController : Controller
    {
        private Cart _cart;
        private IBannerService _bannerService;
        private IDictionary<string, string> _siteSettings;
        private ICommonService _commonService;
        private IProductService _productService;

        public CartController(Cart cart, IBannerService bannerService, ICommonService commonService, IProductService productService)
        {
            _cart = cart;
            _bannerService = bannerService;
            _commonService = commonService;
            _siteSettings = _commonService.GetSiteSettings();
            _productService = productService;
        }
        public ActionResult Cart()
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartLineDTO, CartLine>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            CartViewModel model = mapper.Map<CartViewModel>(_cart);

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

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCart(CartViewModel cart)
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartLine, CartLineDTO>();
                cfg.CreateMap<ProductPageViewModel, ProductPageDTO>();
                cfg.CreateMap<ImageViewModel, ImageDTO>();
            }).CreateMapper();

            ICollection<CartLineDTO> model = mapper.Map<ICollection<CartLineDTO>>(cart.CartLines);

            _cart.UpdateCart(model);

            return RedirectToAction("Cart");
        }

        public ActionResult Clear()
        {
            _cart.Clear();

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            ProductPageDTO product = _productService.GetProduct(productId);
            _cart.AddItem(product, quantity);

            return RedirectToAction("Index", "Home");
        }
    }
}
