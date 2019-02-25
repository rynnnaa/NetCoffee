using CoffeeShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Models.Services
{

    public class CoffeeManager : IInventory
    {
        private readonly CoffeeShopDbContext _context;
        private object coffee;

        public object ModelState { get; private set; }

        public CoffeeManager(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateCoffee(Coffee coffee)
        {
            _context.Coffee.Add(coffee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Coffee>> GetCoffee()
        {
            return await _context.Coffee.ToListAsync();
        }

        public async Task DeleteCoffee(int id)
        {
            Coffee coffee = await _context.Coffee.FindAsync(id);
            if (coffee != null)
            {
                _context.Remove(coffee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Coffee> GetCoffee(int id)
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

        public async Task UpdateCoffee(Coffee coffee)
        {
            _context.Coffee.Update(coffee);
            await _context.SaveChangesAsync();

        }

        //bool exists

        public bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(a => a.ID == id);
        }

        public async Task<Coffee> GetCoffee(int? id)
        {
            return await _context.Coffee.FirstOrDefaultAsync(a => a.ID == id);
        }

        [HttpPost]
        public async Task<List<Coffee>> GetAllCoffee()
        {

            return await _context.Coffee.ToListAsync();
        }
    }
}
