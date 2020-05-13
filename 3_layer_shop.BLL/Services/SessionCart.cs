using _3_layer_shop.BLL.Abstract;
using _3_layer_shop.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(ProductPageDTO product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }

        public override void RemoveItem(ProductPageDTO product)
        {
            base.RemoveItem(product);
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }

        public override void UpdateCart(ICollection<CartLineDTO> changedLines)
        {
            base.UpdateCart(changedLines);
            Session.SetString("Cart", JsonConvert.SerializeObject(this));
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
