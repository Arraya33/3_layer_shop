using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class BannerDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ImageDTO Image { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
