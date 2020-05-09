using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbCommonService : ICommonService
    {
        private SiteDbContext _dbContext;
        private IMemoryCache _cache;
        public DbCommonService(SiteDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _cache = memoryCache;
        }

        public HomePageDTO GetHomePage()
        {
            IEnumerable<Product> products = _dbContext.Products.Include(p => p.Page).Include(p => p.MainImage).OrderByDescending(p => p.DateAdded).Take(8);

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductPageDTO>()
                    .ForMember(prodDTO => prodDTO.Alias, opt => opt.MapFrom(p => p.Page.Alias));
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();

            IEnumerable<ProductPageDTO> productsDTO = mapper.Map<IEnumerable<ProductPageDTO>>(products);

            HomePageDTO homePage = new HomePageDTO { Products = productsDTO, Title = "Главная" };

            return homePage;
        }

        public IDictionary<string, string> GetSiteSettings()
        {
            IEnumerable<Setting> settings = null;

            if (!_cache.TryGetValue("siteSettings", out settings))
            {
                settings = _dbContext.Settings.ToList();
                
                if (settings != null)
                {
                    _cache.Set("siteSettings", settings, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            Dictionary<string, string> settingsDisctionary = settings.ToDictionary(sKey => sKey.Key, sVal => sVal.Value);

            return settingsDisctionary;
        }
    }
}
