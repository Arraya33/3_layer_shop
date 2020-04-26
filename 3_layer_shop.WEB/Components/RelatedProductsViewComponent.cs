using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class RelatedProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ProductPageViewModel> products)
        {
            return View(products);
        }
    }
}
