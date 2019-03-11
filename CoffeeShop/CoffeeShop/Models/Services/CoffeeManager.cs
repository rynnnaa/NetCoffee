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


        public object ModelState { get; private set; }

        public IEnumerable<Coffee> Coffee { get; set; }

        public CoffeeManager(CoffeeShopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new coffee object to the database
        /// </summary>
        /// <param name="coffee"></param>
        /// <returns>Saves changes</returns>
        public async Task CreateCoffee(Coffee coffee)
        {
            _context.Coffee.Add(coffee);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Grabs ID of specific coffee object and deletes it.\
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCoffee(int id)
        {
            Coffee coffee = await _context.Coffee.FindAsync(id);
            if (coffee != null)
            {
                _context.Remove(coffee);
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Returns one coffee object based on its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Coffee> GetCoffee(int id)
        {
            Coffee coffee = await _context.Coffee.FirstOrDefaultAsync(c => c.ID == id);
            return coffee;
        }
        /// <summary>
        /// Updates or Saves a new coffee object. 
        /// </summary>
        /// <param name="coffee"></param>
        /// <returns></returns>
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
        /// <summary>
        // Edit and save a new coffee object
        /// </summary>
        /// <param name="coffee"></param>
        /// <returns></returns>
        public async Task UpdateCoffee(Coffee coffee)
        {
            _context.Coffee.Update(coffee);
            await _context.SaveChangesAsync();

        }


        /// <summary>
        /// Returns a coffee object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Coffee> GetCoffee(int? id)
        {
            return await _context.Coffee.FirstOrDefaultAsync(a => a.ID == id);
        }
        /// <summary>
        /// Returns a list of coffee objects. 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Coffee>> GetAllCoffee()
        {

            return await _context.Coffee.ToListAsync();
        }

        public async Task<Coffee> FindCoffee(int id)
        {
            Coffee coffee = await _context.Coffee.FirstOrDefaultAsync(cof => cof.ID == id);
            return coffee;
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
    }
}