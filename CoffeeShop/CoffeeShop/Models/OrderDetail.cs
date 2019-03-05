using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int CoffeeId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public Coffee Coffee { get; set; }

        public Order Order { get; set; }
    }
}
