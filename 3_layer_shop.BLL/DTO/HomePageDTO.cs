using _3_layer_shop.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO
{
    public class HomePageDTO : PageDTO
    {
        public IEnumerable<ProductPageDTO> Products { get; set; }
    }
}
