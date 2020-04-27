using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<ProductListPageViewModel> ProductCateories { get; set; }
        public IEnumerable<InformationPageViewModel> Informations { get; set; }
    }
}
