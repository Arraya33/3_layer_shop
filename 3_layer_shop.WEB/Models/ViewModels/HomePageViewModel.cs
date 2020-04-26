using _3_layer_shop.WEB.Models.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class HomePageViewModel : PageViewModel
    {
        public IEnumerable<ProductPageViewModel> Products { get; set; }
    }
}
