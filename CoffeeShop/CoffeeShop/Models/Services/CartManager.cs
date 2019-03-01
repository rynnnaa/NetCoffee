using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Services
{
    public class CartManager : ICart
    {
        private readonly CoffeeShopDbContext _context;

        public CartManager(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateACart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCart(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetACart(int? id)
        {
            return await _context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            return await _context.Carts.Include(c => c.Products).ToListAsync();
        }

        public async Task UpdateACart(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}
