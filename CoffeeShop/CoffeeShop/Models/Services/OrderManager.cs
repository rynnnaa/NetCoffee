using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Services
{
    public class OrderManager : IOrder
    {
        private readonly CoffeeShopDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderManager(CoffeeShopDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Create an instance of an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    CoffeeId = item.Coffee.ID,
                    OrderId = order.OrderId,
                    Price = item.Coffee.Price
                };
                await _context.OrderDetails.AddAsync(orderDetail);
            }
             await _context.SaveChangesAsync();
        }
    }
}
