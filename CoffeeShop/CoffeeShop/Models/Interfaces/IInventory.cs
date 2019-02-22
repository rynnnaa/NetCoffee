using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Interfaces
{
    public interface IInventory
    {

        // Create
        

        // Delete
        Task DeleteAsync(int id);
        
        // Find
        Task<Coffee> GetByID(int id);

        // GetAll
        Task<List<Coffee>> GetAllCoffee();

        // Save
        Task SaveAsync(Coffee coffee);
    }
}
