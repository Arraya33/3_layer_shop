﻿using _3_layer_shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface ICommonService
    {
        public HomePageDTO GetHomePage();
        public IDictionary<string, string> GetSiteSettings();
    }
}
