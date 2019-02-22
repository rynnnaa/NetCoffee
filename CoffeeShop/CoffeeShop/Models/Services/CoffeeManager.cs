using CoffeeShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models.Services
{
   
    public class CoffeeManager : IInventory
    {
        private readonly CoffeeShopDbContext _context;

        public CoffeeManager(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            Coffee coffee = await _context.Coffee.FindAsync(id);
            if (coffee != null)
            {
                _context.Remove(coffee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Coffee>> GetAllCoffee()
        {
            return await _context.Coffee.ToListAsync();
        }

        public async Task<Coffee> GetByID(int id)
        {
            Coffee coffee = await _context.Coffee.FirstOrDefaultAsync(c => c.ID == id);
            return coffee;
        }

        public async Task SaveAsync(Coffee coffee)
        {
            if (await _context.Coffee.FirstOrDefaultAsync(c => c.ID == coffee.ID) == null)
            {
                _context.Coffee.Add(coffee);
            }
            else
            {
                
                _context.Coffee.Update(coffee);
            }
            await _context.SaveChangesAsync();
        }
    }
}
