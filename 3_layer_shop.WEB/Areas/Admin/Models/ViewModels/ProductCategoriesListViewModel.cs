using _3_layer_shop.WEB.Models;
using _3_layer_shop.WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Areas.Admin.Models.ViewModels
{
    public class ProductCategoriesListViewModel
    {
        public IEnumerable<ProductListPageViewModel> ProductCategories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
