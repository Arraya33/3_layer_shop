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
        IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        public ActionResult Article(string articleAlias)
        {
            InformationPageDTO informationPageDTO = _informationService.GetArticlePage(articleAlias);

            if (informationPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<InformationPageDTO, InformationPageViewModel>()).CreateMapper();
            InformationPageViewModel model = mapper.Map<InformationPageViewModel>(informationPageDTO);

            ViewBag.Title = model.Title;
            ViewBag.SingleBanner = new BannerViewModel { Description = "ewrwe werwerw", Title = "titleee", Image = new ImageViewModel { Path = "/images/avds_xl.jpg" }, Link = "https://www.google.com" };

            return View(model);
        }
    }
}
