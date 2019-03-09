﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Interfaces
{
    public interface IInventory
    {

        // Create
        Task CreateCoffee(Coffee coffee);

        // Delete
        Task DeleteCoffee(int id);

        // GetAll
        Task<List<Coffee>> GetAllCoffee();

        // Read
        Task<Coffee> GetCoffee(int? id);
        Task<IEnumerable<Coffee>> GetCoffee();

        bool CoffeeExists(int id);
        Task FindCoffee(int iD);
        Task SaveAsync(object cof);
        Task DeleteAsync(int value);

        //// Save
        //Task SaveAsync(Coffee coffee);
    }
}
