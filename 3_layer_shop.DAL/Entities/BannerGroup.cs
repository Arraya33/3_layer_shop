using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class BannerGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Banner> Banners { get; set; }
    }
}
