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
        ICommonService _commonService;
        IBannerService _bannerService;

        public HomeController(ICommonService commonService, IBannerService bannerService)
        {
            _commonService = commonService;
            _bannerService = bannerService;
        }

        public ActionResult Index()
        {
            HomePageDTO homePageDTO = _commonService.GetHomePage();

            IMapper HomePageMapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<HomePageDTO, HomePageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            HomePageViewModel model = HomePageMapper.Map<HomePageViewModel>(homePageDTO) 
                ?? new HomePageViewModel { Title = "Главная страница", Products = new List<ProductPageViewModel>() };

            BannerGroupDTO bannerGroupDTO = _bannerService.GetHomeBannerGroup();

            IMapper BannerGroupMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BannerGroupDTO, BannerGroupViewModel>();
                cfg.CreateMap<BannerDTO, BannerViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            BannerGroupViewModel bannerGroup = BannerGroupMapper.Map<BannerGroupViewModel>(bannerGroupDTO);

            ViewBag.Title = model.Title;
            ViewBag.HomeBannerGroup = bannerGroup;

            return View(model);
        }
    }
}