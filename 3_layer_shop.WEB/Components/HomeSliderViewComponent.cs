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
    public class HomeSliderViewComponent : ViewComponent
    {
        IBannerService _bannerService;

        public HomeSliderViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke(int bannerGroupId)
        {
            BannerGroupDTO bannerGroupDTO = _bannerService.GetBannerGroup(bannerGroupId);

            IMapper mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<BannerGroupDTO, BannerGroupViewModel>();
                cfg.CreateMap<BannerDTO, BannerViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            BannerGroupViewModel model = mapper.Map<BannerGroupViewModel>(bannerGroupDTO);

            return View(model);
        }
    }
}
