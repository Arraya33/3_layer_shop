using _3_layer_shop.WEB.Models.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class ProductListPageViewModel : PageViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ProductPageViewModel> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
