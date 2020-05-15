using _3_layer_shop.BLL.Abstract;
using Newtonsoft.Json;
using _3_layer_shop.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _3_layer_shop.BLL.Services
{
    public class SessionCartFactory : ICartFactory
    {
        private IServiceProvider _services;

        public SessionCartFactory(IServiceProvider services)
        {
            _services = services;
        }

        public Cart GetCart()
        {
            ISession session = _services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            SessionCart cart = JsonConvert.DeserializeObject<SessionCart>(session?.GetString("Cart") ?? "") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }
    }
}
