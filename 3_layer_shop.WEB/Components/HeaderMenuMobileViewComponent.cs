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
    public class HeaderMenuMobileViewComponent : ViewComponent
    {
        readonly IProductService _productService;
        readonly IInformationService _informationService;

        public HeaderMenuMobileViewComponent(IProductService productService, IInformationService informationService)
        {
            _productService = productService;
            _informationService = informationService;
        }

        public IViewComponentResult Invoke()
        {
            MenuViewModel model = new MenuViewModel();

            IEnumerable<ProductCategoryDTO> productCategoryDTOs = _productService.GetProductCategoryList();
            IMapper productMapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductListViewModel>()).CreateMapper();
            IEnumerable<ProductListViewModel> productCateories = productMapper.Map<IEnumerable<ProductListViewModel>>(productCategoryDTOs);
            model.ProductCateories = productCateories;

            IEnumerable<InformationDTO> informationDTOs = _informationService.GetInformationList();
            IMapper informationMapper = new MapperConfiguration(cfg => cfg.CreateMap<InformationDTO, InformationViewModel>()).CreateMapper();
            IEnumerable<InformationViewModel> informationList = informationMapper.Map<IEnumerable<InformationViewModel>>(informationDTOs);
            model.Informations = informationList;

            return View(model);
        }
    }
}
