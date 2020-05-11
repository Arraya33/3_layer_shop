using _3_layer_shop.BLL.Abstract;
using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ICommonService _commonService;
        private IBannerService _bannerService;
        private IDictionary<string, string> _siteSettings;

        public HomeController(ICommonService commonService, IBannerService bannerService)
        {
            _commonService = commonService;
            _bannerService = bannerService;
            _siteSettings = _commonService.GetSiteSettings();
        }

        public ActionResult Index()
        {
            HomePageDTO homePageDTO = _commonService.GetHomePage();

            IMapper homePageMapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<HomePageDTO, HomePageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            HomePageViewModel model = homePageMapper.Map<HomePageViewModel>(homePageDTO) 
                ?? new HomePageViewModel { Title = "Главная страница" };

            if (_siteSettings.TryGetValue("HomeSliderId", out string bannerGroupIdString))
                if ( int.TryParse(bannerGroupIdString, out int bannerGroupId))
                {
                    BannerGroupDTO bannerGroupDTO = _bannerService.GetBannerGroup(bannerGroupId);

                    IMapper BannerGroupMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerGroupDTO, BannerGroupViewModel>();
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerGroupViewModel bannerGroup = BannerGroupMapper.Map<BannerGroupViewModel>(bannerGroupDTO);
                    ViewBag.HomeBannerGroup = bannerGroup;
                }


            if (_siteSettings.TryGetValue("SmallBannerId", out string bannerIdString))
                if (int.TryParse(bannerIdString, out int singleBannerId))
                {
                    BannerDTO bannerDTO = _bannerService.GetBanner(singleBannerId);

                    IMapper BannerMapper = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BannerDTO, BannerViewModel>();
                        cfg.CreateMap<ImageDTO, ImageViewModel>();
                    }).CreateMapper();
                    BannerViewModel banner = BannerMapper.Map<BannerViewModel>(bannerDTO);
                    ViewBag.SingleBanner = banner;
                }

            ViewBag.Title = model.Title;
            
            return View(model);
        }
    }
}