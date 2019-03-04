using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Services
{
    public class ProductManager : IProduct
    {
        private readonly CoffeeShopDbContext _context;

        public ProductManager(CoffeeShopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a product to the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }
        /// <summary>
        /// Removes a product from the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

        }
        /// <summary>
        /// Gets all products within the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(item => item.Coffee).ToListAsync();
        }

        /// <summary>
        /// Gets a product within the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetAProduct(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
