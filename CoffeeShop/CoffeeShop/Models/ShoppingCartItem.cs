using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Coffee Coffee { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
