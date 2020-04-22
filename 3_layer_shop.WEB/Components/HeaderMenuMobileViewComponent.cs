using _3_layer_shop.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Components
{
    public class HeaderMenuMobileViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MenuViewModel model = new MenuViewModel();

            model.ProductCateories = new List<ProductListViewModel>
            {
                new ProductListViewModel { Alias = "category_1", Name = "category 1" },
                new ProductListViewModel { Alias = "category_2", Name = "category 2" },
                new ProductListViewModel { Alias = "category_3", Name = "category 3" },
                new ProductListViewModel { Alias = "category_4", Name = "category 4" }
            };
            model.Informations = new List<InformationViewModel>
            {
                new InformationViewModel { Alias = "article_1", Name = "article 1" },
                new InformationViewModel { Alias = "article_2", Name = "article 2" },
                new InformationViewModel { Alias = "article_3", Name = "article 3" }
            };

            return View(model);
        }
    }
}
