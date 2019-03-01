using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Interfaces
{
    public interface ICart
    {
        // Creates a cart object
        Task CreateACart(Cart cart);

        // Updates a cart object
        Task UpdateACart(Cart cart);

        // Get cart by id
        Task<Cart> GetACart(int? id);
        
        // Get All Carts
        Task<IEnumerable<Cart>> GetAllCarts();

        // Delete A Cart
        Task DeleteCart(Cart cart);
    }
}
