using _3_layer_shop.BLL.Abstract;
using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_layer_shop.BLL.DTO;
using _3_layer_shop.WEB.Models;
using _3_layer_shop.BLL.Services;

namespace _3_layer_shop.WEB.Components
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private Cart _cart;

        public ShoppingCartViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartLineDTO, CartLine>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
            }).CreateMapper();
            CartViewModel model = mapper.Map<CartViewModel>(_cart);

            return View(model);
        }
    }
}