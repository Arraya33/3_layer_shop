using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
