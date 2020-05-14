using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class CartLine
    {
        public int Id { get; set; }
        public Checkout Checkout { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
