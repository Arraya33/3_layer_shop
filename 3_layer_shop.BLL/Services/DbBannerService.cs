using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbBannerService : IBannerService
    {
        public BannerGroupDTO GetBannerGroup(int bannerGroupId)
        {
            BannerGroupDTO bannerGroup = new BannerGroupDTO
            {
                Banners = new List<BannerDTO>
                {
                    new BannerDTO {
                        Image = "/images/home_slider_1.jpg",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                        Link = "https://google.com",
                        Title = "Banner 1"  
                    },
                    new BannerDTO {
                        Image = "/images/home_slider_1.jpg",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                        Link = "https://google.com",
                        Title = "Banner 2"
                    },
                    new BannerDTO {
                        Image = "/images/home_slider_1.jpg",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Text text text",
                        Link = "https://google.com",
                        Title = "Banner 3"
                    }
                }
            };

            return bannerGroup;
        }
    }
}
