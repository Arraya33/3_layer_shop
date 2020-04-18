﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}