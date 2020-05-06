using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbInformationService : IInformationService
    {
        private SiteDbContext _dbContext;
        public DbInformationService(SiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<InformationPageDTO> GetInformationList()
        {
            IEnumerable<InformationPageDTO> informationList = _dbContext.Informations
                .Select(i => new InformationPageDTO { Alias = i.Page.Alias, Name = i.Name });

            return informationList;
        }

        public InformationPageDTO GetArticlePage(string articleAlias)
        {
            Information information = _dbContext.Informations.Include(i => i.Page).FirstOrDefault(i => i.Page.Alias == articleAlias);

            if (information == null || information.Page == null)
            {
                return null;
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Information, InformationPageDTO>()
                    .ForMember(infDTO => infDTO.Alias, opt => opt.MapFrom(inf => inf.Page.Alias))
                    .ForMember(infDTO => infDTO.Description, opt => opt.MapFrom(inf => inf.Page.Description))
                    .ForMember(infDTO => infDTO.Title, opt => opt.MapFrom(inf => inf.Page.Title));
            }).CreateMapper();

            InformationPageDTO informationPage = mapper.Map<InformationPageDTO>(information);

            return informationPage;
        }
    }
}
