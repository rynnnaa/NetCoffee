using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }

        // Nav props
        public Cart Cart { get; set; }
        public Coffee Coffee { get; set; }
    }
}
