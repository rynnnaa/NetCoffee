using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public bool Taken { get; set; }

         // Nav prop;
         public List<Product> Product { get; set; }
    }
}
