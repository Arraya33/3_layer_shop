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
    public class HeaderMenuViewComponent : ViewComponent
    {
        readonly IProductService _productService;
        readonly IInformationService _informationService;

        public HeaderMenuViewComponent(IProductService productService, IInformationService informationService)
        {
            _productService = productService;
            _informationService = informationService;
        }

        public IViewComponentResult Invoke()
        {
            MenuViewModel model = new MenuViewModel();

            IEnumerable<ProductCategoryPageDTO> productCategoryDTOs = _productService.GetProductCategoryList();
            IMapper productMapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>()).CreateMapper();
            IEnumerable<ProductListPageViewModel> productCateories = productMapper.Map<IEnumerable<ProductListPageViewModel>>(productCategoryDTOs);
            model.ProductCateories = productCateories;

            IEnumerable<InformationPageDTO> informationDTOs = _informationService.GetInformationList();
            IMapper informationMapper = new MapperConfiguration(cfg => cfg.CreateMap<InformationPageDTO, InformationPageViewModel>()).CreateMapper();
            IEnumerable<InformationPageViewModel> informationList = informationMapper.Map<IEnumerable<InformationPageViewModel>>(informationDTOs);
            model.Informations = informationList;

            return View(model);
        }
    }
}
