using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class ImageToProduct
    {
        public Image Image { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
    }
}
