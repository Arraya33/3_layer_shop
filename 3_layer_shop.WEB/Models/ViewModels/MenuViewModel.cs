using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<ProductListViewModel> ProductCateories { get; set; }
        public IEnumerable<InformationViewModel> Informations { get; set; }
    }
}
