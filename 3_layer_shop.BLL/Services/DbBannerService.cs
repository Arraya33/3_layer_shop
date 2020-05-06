using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbBannerService : IBannerService
    {
        private SiteDbContext _dbContext;
        public DbBannerService(SiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BannerGroupDTO GetBannerGroup(int bannerGroupId)
        {
            BannerGroup bannerGroup = _dbContext.BannerGroups.Include(bg => bg.Banners).ThenInclude(b => b.Image).FirstOrDefault(bg => bg.Id == bannerGroupId);

            if (bannerGroup == null)
            {
                return null;
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BannerGroup, BannerGroupDTO>();
                cfg.CreateMap<Banner, BannerDTO>();
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();

            BannerGroupDTO bannerGroupDTO = mapper.Map<BannerGroupDTO>(bannerGroup);

            return bannerGroupDTO;
        }

        public BannerGroupDTO GetHomeBannerGroup()
        {
            int.TryParse(_dbContext.Settings.FirstOrDefault(s => s.Key == "HomeSliderId").Value, out int bannerGroupId);

            return GetBannerGroup(bannerGroupId);
        }
    }
}
