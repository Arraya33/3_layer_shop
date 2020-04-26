using _3_layer_shop.BLL.DTO;
using _3_layer_shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Services
{
    public class DbInformationService : IInformationService
    {
        public IEnumerable<InformationPageDTO> GetInformationList()
        {
            IEnumerable<InformationPageDTO> informationList = new List<InformationPageDTO>
            {
                new InformationPageDTO { Alias = "article_1", Name = "article 1" },
                new InformationPageDTO { Alias = "article_2", Name = "article 2" },
                new InformationPageDTO { Alias = "article_3", Name = "article 3" }
            };
            return informationList;
        }
    }
}
