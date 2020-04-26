using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public int BannerGroupId { get; set; }
    }
}
