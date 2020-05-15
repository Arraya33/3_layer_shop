using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
