using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Infrastructure;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbCheckoutService : ICheckoutService
    {
        private SiteDbContext _dbContext;
        public DbCheckoutService(SiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MakeOrder(CheckoutDTO checkoutDTO)
        {
            if(!checkoutDTO.CartLines.Any())
                throw new ValidationException("корзина пуста!", "CartLines");
            if(checkoutDTO.FirstName == null)
                throw new ValidationException("некорректное имя!", "FirstName");
            if (checkoutDTO.LastName == null)
                throw new ValidationException("некоректная фамилия!", "LastName");
            if (checkoutDTO.Address == null)
                throw new ValidationException("некоректный адрес!", "LastName");
            if (checkoutDTO.Email == null)
                throw new ValidationException("некоректный email!", "LastName");

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CheckoutDTO, Checkout>();
                cfg.CreateMap<CartLineDTO, CartLine>()
                    .ForMember(cl => cl.Product, (options) => options.Ignore())
                    .ForMember(cl => cl.ProductId, opt => opt.MapFrom(clDTO => clDTO.Product.Id));
            }).CreateMapper();
            Checkout checkout = mapper.Map<Checkout>(checkoutDTO);
            checkout.Status = _dbContext.Statuses.FirstOrDefault(s => s.Code == 1);

            if(checkout.Status == null)
                throw new ValidationException("ошибка на сервере!", "");

            _dbContext.Checkouts.Add(checkout);
            _dbContext.SaveChanges();
        }
    }
}
