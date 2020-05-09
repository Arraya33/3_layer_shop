using _3_layer_shop.BLL.DTO;
using _3_layer_shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IBannerService
    {
        public BannerGroupDTO GetBannerGroup(int bannerGroupId);

        public BannerDTO GetBanner(int bannerId);
    }
}
