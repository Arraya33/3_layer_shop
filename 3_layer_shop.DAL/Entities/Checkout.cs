using System;
using System.Collections.Generic;
using System.Text;

namespace _3_layer_shop.DAL.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        public ICollection<CartLine> CartLines { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
    }
}
