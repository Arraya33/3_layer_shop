using _3_layer_shop.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface ICartFactory
    {
        public Cart GetCart();
    }
}
