using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class BannerGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BannerViewModel> Banners { get; set; }
    }
}
