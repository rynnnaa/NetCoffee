using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Interfaces
{
    public interface IProduct
    {
        // Create a product
        Task CreateProduct(Product product);
        
        // Update a product
        Task UpdateProduct(Product product);
        
        // Delete a product
        Task DeleteProduct(Product product);

        // Get a product
        Task<Product> GetAProduct(int? id);

        // Get all products
        Task<IEnumerable<Product>> GetAllProducts();

        
    }
}
