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
        public void CanGetOrderId()
        {
            Order order = new Order();
            order.OrderId = 1;

            Assert.Equal(1, order.OrderId);
        }

        [Fact]
        public void CanSetOrderId()
        {
            Order order = new Order();
            order.OrderId = 1;
            order.OrderId = 2;

            Assert.Equal(2, order.OrderId);
        }

        [Fact]
        public void CanGetOrderEmail()
        {
            Order order = new Order();
            order.Email = "order@hotmail.com";

            Assert.Equal("order@hotmail.com", order.Email);
        }

        [Fact]
        public void CanSetOrderEmail()
        {
            Order order = new Order();
            order.Email = "order@yahoo.com";
            order.Email = "order@hotmail.com";

            Assert.Equal("order@hotmail.com", order.Email);
        }

        [Fact]
        public void CanGetOrderFirstName()
        {
            Order order = new Order();
            order.FirstName = "luther";

            Assert.Equal("luther", order.FirstName);
        }

        [Fact]
        public void CanSetOrderFirstName()
        {
            Order order = new Order();
            order.FirstName = "ryna";
            order.FirstName = "luther";

            Assert.Equal("luthr", order.FirstName);
        }

        [Fact]
        public void CanGetOrderLastName()
        {
            Order order = new Order();
            order.LastName = "luther";

            Assert.Equal("luther", order.LastName);
        }

        [Fact]
        public void CanSetOrderLastName()
        {
            Order order = new Order();
            order.LastName = "ray";
            order.LastName = "luther";

            Assert.Equal("luther", order.LastName);
        }

        //[Fact]
        //public void CanGetOrderLines()
        //{
        //    Order order = new Order();
        //    order.OrderLines = ;

        //    Assert.Equal("luther", order.OrderLines);
        //}

        //[Fact]
        //public void CanSetOrderLines()
        //{
        //    Order order = new Order();
        //    order.OrderLines = ;

        //    Assert.Equal("luther", order.OrderLines);
        //}

        [Fact]
        public void CanGetOrderLines()
        {
            Order order = new Order();
            order.OrderLines = ;

            Assert.Equal("luther", order.OrderLines);
        }

    }
}
