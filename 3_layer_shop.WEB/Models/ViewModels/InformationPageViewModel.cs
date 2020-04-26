using _3_layer_shop.WEB.Models.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class InformationPageViewModel : PageViewModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
