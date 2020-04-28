using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class BannerGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
    }
}
