﻿using _3_layer_shop.BLL.DTO;
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

        public HomeController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public ActionResult Index()
        {
            HomePageDTO homePageDTO = _commonService.GetHomePage();

            IMapper mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<HomePageDTO, HomePageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            HomePageViewModel model = mapper.Map<HomePageViewModel>(homePageDTO) 
                ?? new HomePageViewModel { Title = "Главная страница", Products = new List<ProductPageViewModel>() };

            ViewBag.Title = model.Title;
            ViewBag.HomeBannerGroupId = _commonService.GetHomeBannerGroupId();

            return View(model);
        }
    }
}