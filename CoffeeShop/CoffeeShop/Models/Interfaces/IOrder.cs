using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Interfaces
{
    public interface IOrder
    {
        Task CreateOrder(Order order);
    }
}
