﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.Models.ViewModels
{
    public class CartViewModel
    {
        public IList<CartLine> CartLines { get; set; }
        public int TotalValue { get; set; }
        public int TotalQuantity { get; set; }
    }
}
