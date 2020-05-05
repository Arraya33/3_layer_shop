using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.DTO.Abstract
{
    public abstract class PageDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
