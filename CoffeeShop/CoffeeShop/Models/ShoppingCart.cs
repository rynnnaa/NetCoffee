namespace CoffeeShop.Models
{
    using CoffeeShop.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ShoppingCart" />
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly CoffeeShopDbContext _context;

        /// <summary>
        /// Prevents a default instance of the <see cref="ShoppingCart"/> class from being created.
        /// </summary>
        /// <param name="context">The context<see cref="CoffeeShopDbContext"/></param>
        private ShoppingCart(CoffeeShopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets or sets the ShoppingCartId
        /// </summary>
        public string ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartItems
        /// </summary>
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        /// <summary>
        /// The GetCart
        /// </summary>
        /// <param name="services">The services<see cref="IServiceProvider"/></param>
        /// <returns>The <see cref="ShoppingCart"/></returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<CoffeeShopDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        /// <summary>
        /// The AddToCart
        /// </summary>
        /// <param name="coffee">The coffee<see cref="Coffee"/></param>
        /// <param name="amount">The amount<see cref="int"/></param>
        public void AddToCart(Coffee coffee, int amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Coffee.ID == coffee.ID && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Coffee = coffee,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// The RemoveFromCart
        /// </summary>
        /// <param name="coffee">The coffee<see cref="Coffee"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int RemoveFromCart(Coffee coffee)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Coffee.ID == coffee.ID && s.ShoppingCartId == ShoppingCartId);

            int userAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    userAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

            }
            _context.SaveChanges();
            return userAmount;
        }

        /// <summary>
        /// The GetShoppingCartItems
        /// </summary>
        /// <returns>The <see cref="List{ShoppingCartItem}"/></returns>
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Coffee).ToList());
        }

        /// <summary>
        /// The GetTotal
        /// </summary>
        /// <returns>The <see cref="decimal"/></returns>
        public decimal GetTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Amount).Sum();
            return total;
        }
    }
}
