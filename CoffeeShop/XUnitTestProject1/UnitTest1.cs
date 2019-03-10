using CoffeeShop.Models;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetCoffee()
        {
            Coffee coffee = new Coffee();
            coffee.Name = "Latte";

            Assert.Equal("Latte", coffee.Name);
        }

        [Fact]
        public void CanSetCoffee()
        {
            Coffee coffee = new Coffee();
            coffee.Name = "Espresso";
            coffee.Name = "Latte";         

            Assert.Equal("Latte", coffee.Name);
        }
    }
}
