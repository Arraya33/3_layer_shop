using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class SliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BannerGroupViewModel bannerGroup)
        {
            return View(bannerGroup);
        }
    }
}
