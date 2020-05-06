using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class BannerViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ImageViewModel Image { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
