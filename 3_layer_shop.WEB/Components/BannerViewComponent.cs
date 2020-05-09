using _3_layer_shop.WEB.Enums;
using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BannerViewModel banner, BannerType bannerType = BannerType.Small)
        {
            switch (bannerType)
            {
                case BannerType.Big:
                    return View("Big", banner);
                case BannerType.Small:
                default:
                    return View(banner);
            }          
        }
    }
}
