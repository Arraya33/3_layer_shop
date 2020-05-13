using _3_layer_shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Abstract
{
    public abstract class Cart
    {
        public ICollection<CartLineDTO> CartLines { get; } = new List<CartLineDTO>();
        public int TotalValue { get => CartLines.Sum(cl => cl.Product.DiscountPrice > 0 ? cl.Product.DiscountPrice : cl.Product.Price * cl.Quantity); }
        public int TotalQuantity { get => CartLines.Sum(e => e.Quantity); }

        public virtual void AddItem(ProductPageDTO product, int quantity)
        {
            CartLineDTO cartLine = CartLines.FirstOrDefault(cl => cl.Product.Id == product.Id);
            if(quantity > 0)
            {
                if (cartLine == null)
                {
                    CartLines.Add(new CartLineDTO { Product = product, Quantity = quantity });
                }
                else
                {
                    cartLine.Quantity += quantity;
                }
            }           
        }

        public virtual void UpdateCart(ICollection<CartLineDTO> changedLines)
        {
            foreach (CartLineDTO changedLine in changedLines)
            {
                CartLineDTO cartLine = CartLines.FirstOrDefault(cl => cl.Product.Id == changedLine.Product.Id);
                if (cartLine != null)
                {
                    if (changedLine.Quantity == 0)
                    {
                        CartLines.Remove(cartLine);                       
                    }
                    else if (changedLine.Quantity > 0)
                    {
                        cartLine.Quantity = changedLine.Quantity;
                    }
                }
            }
        }

        public virtual void RemoveItem(ProductPageDTO product) =>
            CartLines.Remove(CartLines.FirstOrDefault(cl => cl.Product.Id == product.Id));

        public virtual void Clear() => CartLines.Clear();
    }
}
