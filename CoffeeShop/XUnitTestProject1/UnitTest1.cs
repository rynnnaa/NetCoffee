using CoffeeShop.Models;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetCoffeeID()
        {
            Coffee coffee = new Coffee();
            coffee.ID = 1;

            Assert.Equal(1, coffee.ID);
        }

        [Fact]
        public void CanSetCoffeeID()
        {
            Coffee coffee = new Coffee();
            coffee.ID = 2;
            coffee.ID = 1;

            Assert.Equal(1, coffee.ID);
        }

        [Fact]
        public void CanGetCoffeeName()
        {
            Coffee coffee = new Coffee();
            coffee.Name = "Latte";

            Assert.Equal("Latte", coffee.Name);
        }

        [Fact]
        public void CanSetCoffeeName()
        {
            Coffee coffee = new Coffee();
            coffee.Name = "Espresso";
            coffee.Name = "Latte";         

            Assert.Equal("Latte", coffee.Name);
        }

        [Fact]
        public void CanGetCoffeePrice()
        {
            Coffee coffee = new Coffee();
            coffee.Price = 1;

            Assert.Equal(1, coffee.Price);
        }

        [Fact]
        public void CanSetCoffeePrice()
        {
            Coffee coffee = new Coffee();
            coffee.Price = 2;
            coffee.Price = 1;

            Assert.Equal(1, coffee.Price);
        }

        [Fact]
        public void CanGetCoffeeURL()
        {
            Coffee coffee = new Coffee();
            coffee.URL = "www.coffee.com";

            Assert.Equal("www.coffee.com", coffee.URL);
        }

        [Fact]
        public void CanSetCoffeeURL()
        {
            Coffee coffee = new Coffee();
            coffee.URL = "www.notcoffee.com";
            coffee.URL = "www.coffee.com";

            Assert.Equal("www.coffee.com", coffee.URL);
        }

        [Fact]
        public void CanGetCoffeeDescription()
        {
            Coffee coffee = new Coffee();
            coffee.Description = "tasty";

            Assert.Equal("tasty", coffee.Description);
        }

        [Fact]
        public void CanSetCoffeeDescription()
        {
            Coffee coffee = new Coffee();
            coffee.Description = "not tasty";
            coffee.Description = "tasty";

            Assert.Equal("tasty", coffee.Description);
        }

        [Fact]
        public void CanGetOrder()
        {
            Coffee coffee = new Coffee();
            coffee.Description = "tasty";

            Assert.Equal("tasty", coffee.Description);
        }
    }
}
}
