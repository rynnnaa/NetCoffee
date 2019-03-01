using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data
{
    public class CoffeeShopDbContext : DbContext
    {
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffee>().HasData(
                new Coffee
                {
                    ID = 1,
                    Name = "Latte",
                    Description = "Strong or bold coffee (sometimes espresso) mixed with scalded milk",
                    URL = "/Assets/latte.jpg",
                    Price = 4.00m
                },
                new Coffee
                {
                    ID = 2,
                    Name = "Americano",
                    Description = "Is a type of coffee drink prepared by diluting an espresso with hot water, giving it a similar strength to, but different flavor from traditionally brewed coffee.",
                    URL = "/Assets/americano.jpg",
                    Price = 3.00m
                },
                new Coffee
                {
                    ID = 3,
                    Name = "Espresso",
                    Description = "Is a full-flavored, concentrated form of coffee that is served in “shots.” It is made by forcing pressurized, hot water through very finely ground coffee beans.",
                    URL = "/Assets/espresso.jpg",
                    Price = 1.00m
                },
                new Coffee
                {
                    ID = 4,
                    Name = "Cold Brew",
                    Description = "Goes through a brewing process to become better",
                    URL = "/Assets/coldBrew.jpg",
                    Price = 5.00m,
                },
                new Coffee
                {
                    ID = 5,
                    Name = "Machiatto",
                    Description = "" ,
                    URL = "/Assets/macchiato.jpg",
                    Price = 3.50m,
                },
                new Coffee
                {
                    ID = 6,
                    Name = "Mocha",
                    Description = "Like a caffe latte, it is typically one third espresso and two thirds steamed milk, but a portion of chocolate is added",
                    URL = "/Assets/mocha.jpg",
                    Price = 4.50m,
                },
                new Coffee
                {
                     ID = 7,
                     Name = "Irish Coffee",
                     Description = " Is a cocktail consisting of hot coffee, Irish whiskey, and sugar, stirred, and topped with cream. The coffee is drunk through the cream.",
                     URL = "/Assets/irishCoffee.jpg",
                    Price = 7.00m,
                },
                new Coffee
                {
                    ID = 8,
                    Name = "Long Black",
                    Description = "It is similar to an Americano, but with a stronger aroma and taste. A long black is made by pouring a double-shot of espresso or ristretto over hot water",
                    URL = "/Assets/longBlack.jpg",
                    Price = 3.75m,
                },
                new Coffee
                {
                    ID = 9,
                    Name = "Flat White",
                    Description = "A flat white is a coffee drink consisting of espresso with microfoam It is comparable to a latte, but smaller in volume and with less microfoam",
                    URL = "/Assets/flatWhite.jpg",
                    Price = 5.75m,
                },
                new Coffee
                {
                    ID = 10,
                    Name = "Cappuccino",
                    Description = " cappuccino is an espresso-based coffee drink that originated in Italy, and is traditionally prepared with an espresso shot and steamed milk foam. Variations of the drink involve the use of cream instead of milk, and flavoring with cinnamon or chocolate powder",
                    URL = "/Assets/cappucino.jpg",
                    Price = 4.00m
                }
                );
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
