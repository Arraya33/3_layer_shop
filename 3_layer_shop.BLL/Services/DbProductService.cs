using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Enums;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using _3_layer_shop.DAL.Entities.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbProductService : IProductService
    {
        private SiteDbContext _dbContext;
        public DbProductService(SiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductCategoryPageDTO GetSearcedProducts(string searchKey)
        {
            IEnumerable<Product> products = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage)
                .Where(p => p.Name.Contains(searchKey));

            //IEnumerable<Product> products = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage)
            //    .Where(p => EF.Functions.Like(p.Name, "") );

            if (!products.Any())
            {
                return new ProductCategoryPageDTO();
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(prod => prod.Page.Alias));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();

            IEnumerable<ProductPageDTO> productsDTO = mapper.Map<IEnumerable<ProductPageDTO>>(products);

            ProductCategoryPageDTO searchedProductsPage = new ProductCategoryPageDTO
            {
                Products = productsDTO,
                Title = "Поиск",
                Name = $"Найденные товары по запросу: {searchKey}"
            };

            return searchedProductsPage;
        }

        public ProductPageDTO GetProductPage(string productAlias)
        {
            Product product = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage)
                .Include(p => p.Images).ThenInclude(itp => itp.Image)
                .Include(p => p.ProductToProductsChilds).ThenInclude(ptp => ptp.ProductChild).ThenInclude(p => p.MainImage)
                .Include(p => p.ProductToProductsChilds).ThenInclude(ptp => ptp.ProductChild).ThenInclude(p => p.Page)
                .FirstOrDefault(p => p.Page.Alias == productAlias);

            if (product == null || product.Page == null)
            {
                return null;
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(prod => prod.Page.Alias))
                    .ForMember(prodDTO => prodDTO.Description, opt => opt.MapFrom(prod => prod.Page.Description))
                    .ForMember(prodDTO => prodDTO.Title, opt => opt.MapFrom(prod => prod.Page.Title))
                    .ForMember(prodDTO => prodDTO.Images, opt => opt.MapFrom(prod => prod.Images.Select(itp => itp.Image)))
                    .ForMember(prodDTO => prodDTO.RelatedProducts, opt => opt.MapFrom(prod => prod.ProductToProductsChilds
                        .Select(ptp => ptp.ProductChild)));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();
            ProductPageDTO productDTO = mapper.Map<ProductPageDTO>(product);

            return productDTO;
        }

        public ProductPageDTO GetProduct(int productId)
        {
            Product product = _dbContext.Products.Include(p => p.MainImage).Include(p => p.Page).FirstOrDefault(p => p.Id == productId);

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(prod => prod.Page.Alias));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();
            ProductPageDTO productDTO = mapper.Map<ProductPageDTO>(product);

            return productDTO;
        }

        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize, ProductOrderType orderType)
        {
            Expression<Func<Product, object>> orderExp;

            switch (orderType)
            {
                case ProductOrderType.Name:
                    orderExp = p => p.Name;
                    break;
                case ProductOrderType.Price:
                    orderExp = p => p.Price;
                    break;
                default:
                    orderExp = p => p.Name;
                    break;
            }

            ProductCategory productCategory = _dbContext.ProductCategories.Include(pc => pc.Page)
                .FirstOrDefault(pc => pc.Page.Alias == categoryAlias);

            if (productCategory == null || productCategory.Page == null)
            {
                return null;
            }

            //выполняется в отдельном зпросе так как невозможно сортировать и выборочно получать продукты в запросе, получающем категорию товаров
            IEnumerable<Product> products = _dbContext.Entry(productCategory).Collection(pc => pc.ProductToCategories).Query()
                .Include(ptc => ptc.Product).ThenInclude(p => p.MainImage).Include(ptc => ptc.Product).ThenInclude(p => p.Page)
                .Select(ptc => ptc.Product).OrderBy(orderExp).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            IMapper categoryMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCategory, ProductCategoryPageDTO>()
                    .ForMember(catDTO => catDTO.Alias, opt => opt.MapFrom(cat => cat.Page.Alias))
                    .ForMember(catDTO => catDTO.Description, opt => opt.MapFrom(cat => cat.Page.Description))
                    .ForMember(catDTO => catDTO.Title, opt => opt.MapFrom(cat => cat.Page.Title));
            }).CreateMapper();

            IMapper productMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(prod => prod.Page.Alias));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();

            ProductCategoryPageDTO productCategoryDTO = categoryMapper.Map<ProductCategoryPageDTO>(productCategory);
            IEnumerable<ProductPageDTO> productsDTO = productMapper.Map<IEnumerable<ProductPageDTO>>(products);

            productCategoryDTO.Products = productsDTO;
            productCategoryDTO.TotalItems = _dbContext.Entry(productCategory).Collection(pc => pc.ProductToCategories).Query().Count();

            return productCategoryDTO;
        }

        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize, ProductOrderType orderType)
        {
            Expression<Func<Product, object>> orderExp;

            switch (orderType)
            {
                case ProductOrderType.Name:
                    orderExp = p => p.Name;
                    break;
                case ProductOrderType.Price:
                    orderExp = p => p.Price;
                    break;
                default:
                    orderExp = p => p.Name;
                    break;
            }

            IEnumerable<Product> products = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage)
                .OrderBy(orderExp).Where(p => p.DiscountPrice > 0).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!products.Any())
            {
                return new ProductCategoryPageDTO();
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(prod => prod.Page.Alias));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();

            IEnumerable<ProductPageDTO> productsDTO = mapper.Map<IEnumerable<ProductPageDTO>>(products);

            ProductCategoryPageDTO discountPage = new ProductCategoryPageDTO
            {
                Products = productsDTO,
                Title = "Товары со скидкой",
                Name = "Товары со скидкой"
            };

            discountPage.TotalItems = _dbContext.Products.Count(p => p.DiscountPrice > 0);

            return discountPage;
        }

        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList()
        {
            IEnumerable<ProductCategoryPageDTO> productCategoryList = _dbContext.ProductCategories
                .Select(pc => new ProductCategoryPageDTO { Name = pc.Name, Alias = pc.Page.Alias, Id = pc.Id });

            return productCategoryList;
        }

        public ProductCategoriesListDTO GetProductCategoryList(int pageNumber, int pageSize)
        {
            IEnumerable<ProductCategoryPageDTO> productCategoryList = _dbContext.ProductCategories
                .Select(pc => new ProductCategoryPageDTO { Name = pc.Name, Alias = pc.Page.Alias, Id = pc.Id })
                .Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ProductCategoriesListDTO productCategories = new ProductCategoriesListDTO
            {
                ProductCategories = productCategoryList,
                TotalItems = _dbContext.ProductCategories.Count()
            };

            return productCategories;
        }
    }
}
