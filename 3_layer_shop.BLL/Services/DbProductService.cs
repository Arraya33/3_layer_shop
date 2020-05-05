using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using _3_layer_shop.DAL.Entities.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ProductPageDTO GetProductPage(string productAlias)
        {
            Product product = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage)
                .Include(p => p.Images).ThenInclude(itp => itp.Image)
                .Include(p => p.ProductToProductsChilds).ThenInclude(ptp => ptp.ProductChild).ThenInclude(p => p.MainImage)
                .Include(p => p.ProductToProductsChilds).ThenInclude(ptp => ptp.ProductChild).ThenInclude(p => p.Page)
                .FirstOrDefault(p => p.Page.Alias == productAlias);

            if (product == null)
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

        public ProductCategoryPageDTO GetProductCategoryPage(string categoryAlias, int pageNumber, int pageSize)
        {
            ProductCategory productCategory = _dbContext.ProductCategories.Include(pc => pc.Page).FirstOrDefault(pc => pc.Page.Alias == categoryAlias);

            if (productCategory == null)
            {
                return null;
            }

            IEnumerable<Product> products = _dbContext.Entry(productCategory).Collection(pc => pc.ProductToCategories).Query()
                .Include(ptc => ptc.Product).ThenInclude(p => p.MainImage).Include(ptc => ptc.Product).ThenInclude(p => p.Page)
                .Select(ptc => ptc.Product).Skip((pageNumber - 1) * pageSize).Take(pageSize);

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

            return productCategoryDTO;
        }

        public ProductCategoryPageDTO GetDiscountProductPage(int pageNumber, int pageSize)
        {
            List<ProductPageDTO> products = new List<ProductPageDTO>();
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_1.jpg", Alt = "product_1" }, Name = "Product1", Alias = "product_1", Price = 123, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_2.jpg", Alt = "product_2" }, Name = "Product2", Alias = "product_2", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_3.jpg", Alt = "product_3" }, Name = "Product3", Alias = "product_3", Price = 6434 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_4.jpg", Alt = "product_4" }, Name = "Product4", Alias = "product_4", Price = 23 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_5.jpg", Alt = "product_5" }, Name = "Product5", Alias = "product_5", Price = 433, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_6.jpg", Alt = "product_6" }, Name = "Product6", Alias = "product_6", Price = 655 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_7.jpg", Alt = "product_7" }, Name = "Product7", Alias = "product_7", Price = 234, DiscountPrice = 55 });
            products.Add(new ProductPageDTO { MainImage = new ImageDTO { Path = "/images/product_8.jpg", Alt = "product_8" }, Name = "Product8", Alias = "product_8", Price = 111 });

            ProductCategoryPageDTO productCategory = new ProductCategoryPageDTO
            {
                Products = products.Skip((pageNumber - 1) * pageSize).Take(pageSize),
                TotalItems = products.Count
            };

            return productCategory;
        }

        public IEnumerable<ProductCategoryPageDTO> GetProductCategoryList()
        {
            List<ProductCategoryPageDTO> productCategoryList = new List<ProductCategoryPageDTO>();
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 1", Alias = "Category1" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 2", Alias = "Category2" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 55", Alias = "Category55" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 4", Alias = "Category4" });
            productCategoryList.Add(new ProductCategoryPageDTO { Name = "Category 5", Alias = "Category5" });

            return productCategoryList;
        }
    }
}
