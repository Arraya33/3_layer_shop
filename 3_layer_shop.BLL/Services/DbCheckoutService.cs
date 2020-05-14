using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Infrastructure;
using _3_layer_shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbCheckoutService : ICheckoutService
    {
        public void MakeOrder(CheckoutDTO checkout)
        {
            if(!checkout.CartLines.Any())
                throw new ValidationException("корзина пуста!", "CartLines");
            if(checkout.FirstName == null)
                throw new ValidationException("некорректное имя!", "FirstName");
            if (checkout.LastName == null)
                throw new ValidationException("некоректная фамилия!", "LastName");
            if (checkout.Address == null)
                throw new ValidationException("некоректный адрес!", "LastName");
            if (checkout.Email == null)
                throw new ValidationException("некоректный email!", "LastName");
        }
    }
}
