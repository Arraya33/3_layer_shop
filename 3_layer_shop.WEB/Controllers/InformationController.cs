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
    public class InformationController : Controller
    {
        private IInformationService _informationService;
        private IBannerService _bannerService;
        private IDictionary<string, string> _siteSettings;
        private ICommonService _commonService;

        public InformationController(IInformationService informationService, IBannerService bannerService, ICommonService commonService)
        {
            _informationService = informationService;
            _bannerService = bannerService;
            _commonService = commonService;
            _siteSettings = _commonService.GetSiteSettings();
        }

        public ActionResult Article(string articleAlias)
        {
            InformationPageDTO informationPageDTO = _informationService.GetArticlePage(articleAlias);

            if (informationPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<InformationPageDTO, InformationPageViewModel>()).CreateMapper();
            InformationPageViewModel model = mapper.Map<InformationPageViewModel>(informationPageDTO);

            if (_siteSettings.TryGetValue("BigBannerId", out string bannerIdString))
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
