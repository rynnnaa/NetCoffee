using System;
using Xunit;
using CoffeeShop.Models;
namespace CoffeeTesting
{
    public class UnitTest1
    {
        [Fact]
        public void CreateApplicationUser()
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Test",
                LastName = "123",
                State = true,
                FavoriteCoffee = "Expresso",
                Birthday = new DateTime(1994, 07, 28)

            };

            Assert.Equal("Test", user.FirstName);
            Assert.Equal("123", user.LastName);
            Assert.True(user.State);
            Assert.Equal("Expresso", user.FavoriteCoffee);
            Assert.Equal("7/28/1994", user.Birthday.ToString());
        }
    }
}
