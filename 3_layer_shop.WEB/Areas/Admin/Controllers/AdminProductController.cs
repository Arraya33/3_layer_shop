using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.WEB.Areas.Admin.Models.ViewModels;
using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminProductController : Controller
    {
        private IWebHostEnvironment _appEnvironment;
        private IProductService _productService;
        private IImageService _imageService;
        int _pageSize;

        public AdminProductController(IProductService productService, IWebHostEnvironment appEnvironment, IImageService imageService)
        {
            _productService = productService;
            _appEnvironment = appEnvironment;
            _imageService = imageService;
            _pageSize = 3;
        }

        public IActionResult ProductCategoriesList(int page = 1)
        {
            ProductCategoriesListDTO productCategoriesDTOs = _productService.GetProductCategoryList(page, _pageSize);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoriesListDTO, ProductCategoriesListViewModel>();
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
            }).CreateMapper();
            ProductCategoriesListViewModel productCateories = mapper.Map<ProductCategoriesListViewModel>(productCategoriesDTOs);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoriesDTOs.TotalItems,
                PageAction = "ProductCategoriesList"
            };

            productCateories.PagingInfo = pagingInfo;

            return View(productCateories);
        }

        public IActionResult ProductsList(int page = 1)
        {
            ProductCategoryPageDTO productDTOs = _productService.GetProductList(page, _pageSize);

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductListPageViewModel model = mapper.Map<ProductListPageViewModel>(productDTOs);

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productDTOs.TotalItems,
                PageAction = "ProductsList"
            };

            model.PagingInfo = pagingInfo;

            return View(model);
        }

        public IActionResult EditProductCategory(int categoryId, int page = 1)
        {
            ProductCategoryPageDTO productCategoryPageDTO = _productService.GetProductCategoryPage(categoryId, page, _pageSize, ProductOrderType.Name);

            if (productCategoryPageDTO == null)
                return NotFound();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategoryPageDTO, ProductListPageViewModel>();
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            ProductListPageViewModel model = mapper.Map<ProductListPageViewModel>(productCategoryPageDTO);

            Dictionary<string, string> pagingParameters = new Dictionary<string, string>();
            pagingParameters.Add("categoryId", categoryId.ToString());

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoryPageDTO.TotalItems,
                PageAction = "EditProductCategory",
                Parameters = pagingParameters
            };

            model.PagingInfo = pagingInfo;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProductCategory(ProductListPageViewModel productListPageViewModel)
        {
            ProductCategoryPageDTO productCategoryPageDTO = _productService
                .GetProductCategoryPage(productListPageViewModel.Id, 1, _pageSize, ProductOrderType.Name);

            if (productCategoryPageDTO == null)
                return NotFound();

            IEnumerable<ProductPageDTO> productDTOs = productCategoryPageDTO?.Products;

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();
            IEnumerable<ProductPageViewModel> products = mapper.Map<IEnumerable<ProductPageViewModel>>(productDTOs);

            productListPageViewModel.Products = products;

            Dictionary<string, string> pagingParameters = new Dictionary<string, string>();
            pagingParameters.Add("categoryId", productCategoryPageDTO.Id.ToString());

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                ItemsPerPage = _pageSize,
                TotalItems = productCategoryPageDTO.TotalItems,
                PageAction = "EditProductCategory",
                Parameters = pagingParameters
            };

            productListPageViewModel.PagingInfo = pagingInfo;

            return View(productListPageViewModel);
        }

        [HttpPost]
        public IActionResult DeleteProductCategory(int categoryId)
        {
            ProductListPageViewModel productListPageViewModel = new ProductListPageViewModel();
            return View(productListPageViewModel);
        }

        public IActionResult EditProduct(int productId)
        {
            ProductPageDTO productPageDTO = _productService.GetProduct(productId);

            if (productPageDTO == null)
                return NotFound();

            IMapper categoryMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPageDTO, ProductPageViewModel>();
                cfg.CreateMap<ImageDTO, ImageViewModel>();
            }).CreateMapper();

            ProductPageViewModel model = categoryMapper.Map<ProductPageViewModel>(productPageDTO);

            model.RelatedProductIds = model.RelatedProducts.Select(p => p.Id).ToArray();

            IEnumerable<ProductPageDTO> productsDTOs = _productService.GetProductList();
            IMapper productMapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductPageDTO, ProductPageViewModel>()).CreateMapper();

            IEnumerable<ProductPageViewModel> products = productMapper.Map<IEnumerable<ProductPageViewModel>>(productsDTOs);

            ViewBag.RelatedProducts = new MultiSelectList(products, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductPageViewModel productPageViewModel)
        {
            return View(productPageViewModel);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            ProductPageViewModel productPageViewModel = new ProductPageViewModel();
            return View(productPageViewModel);
        }

        public ViewResult Create() 
            => View("EditProductCategory", new ProductListPageViewModel());


        [HttpPost]
        public async Task<IActionResult> AddProductImage(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // _appEnvironment.WebRootPath - wwwroot
                string path = await _imageService.UploadImageFileAsync(uploadedFile, _appEnvironment.WebRootPath);
                if (path != null)
                    return Ok(path);
            }
            return BadRequest();
        }
    }
}
