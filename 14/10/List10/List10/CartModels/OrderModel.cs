using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List10.CartModels
{
    public class OrderModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
    }
}
