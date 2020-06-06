using _3_layer_shop.BLL.DTO;
using _3_layer_shop.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IImageService
    {
        public BannerGroupDTO GetBannerGroup(int bannerGroupId);

        public BannerDTO GetBanner(int bannerId);

        public Task<string> UploadImageFileAsync(IFormFile uploadedFile, string path);
    }
}
