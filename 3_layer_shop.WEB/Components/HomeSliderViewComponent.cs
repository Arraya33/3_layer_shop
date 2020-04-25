using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class HomeSliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<BannerViewModel> model = new List<BannerViewModel>();

            model.Add(new BannerViewModel 
            { 
                Image = "/images/home_slider_1.jpg",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                Link = "https://google.com", 
                Title = "Banner 1" 
            });

            model.Add(new BannerViewModel
            {
                Image = "/images/home_slider_1.jpg",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                Link = "https://google.com",
                Title = "Banner 2"
            });

            model.Add(new BannerViewModel
            {
                Image = "/images/home_slider_1.jpg",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                Link = "https://google.com",
                Title = "Banner 3"
            });

            return View(model);
        }
    }
}
