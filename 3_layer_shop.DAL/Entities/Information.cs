using _3_layer_shop.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class Information
    {
        public int Id { get; set; }
        public Page Page { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
