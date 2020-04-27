using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class BannerGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BannerDTO> Banners { get; set; }

    }
}
