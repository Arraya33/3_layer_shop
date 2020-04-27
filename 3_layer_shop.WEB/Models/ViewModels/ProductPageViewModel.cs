using _3_layer_shop.WEB.Models.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class ProductPageViewModel : PageViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string IntroText { get; set; }
        public ImageViewModel MainImage { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductPageViewModel> RelatedProducts { get; set; }
    }
}
