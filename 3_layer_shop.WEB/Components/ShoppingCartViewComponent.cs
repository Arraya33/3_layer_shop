using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private CartViewModel _cart;

        public ShoppingCartViewComponent(CartViewModel cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
