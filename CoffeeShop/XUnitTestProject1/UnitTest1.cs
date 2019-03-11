using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.Services;
using CoffeeShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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


        [Fact]
        public void CanGetOrderDetailId()
        {
            OrderDetail order = new OrderDetail();
            order.OrderDetailId = 1;

            Assert.Equal(1, order.OrderDetailId);
        }

        [Fact]
        public void CanSetOrderDetailId()
        {
            OrderDetail order = new OrderDetail();
            order.OrderDetailId = 2;
            order.OrderDetailId = 1;

            Assert.Equal(1, order.OrderDetailId);
        }

        [Fact]
        public void CanGetOrderDetailOrderId()
        {
            OrderDetail order = new OrderDetail();
            order.OrderId = 1;

            Assert.Equal(1, order.OrderId);
        }

        [Fact]
        public void CanSetOrderDetailOrderId()
        {
            OrderDetail order = new OrderDetail();
            order.OrderId = 2;
            order.OrderId = 1;

            Assert.Equal(1, order.OrderId);
        }

        [Fact]
        public void CanGetOrderDetailCoffee()
        {
            OrderDetail order = new OrderDetail();
            order.CoffeeId = 1;

            Assert.Equal(1, order.CoffeeId);
        }

        [Fact]
        public void CanSetOrderDetailCoffee()
        {
            OrderDetail order = new OrderDetail();
            order.CoffeeId = 2;
            order.CoffeeId = 1;

            Assert.Equal(1, order.CoffeeId);
        }

        [Fact]
        public void CanGetOrderDetailAmount()
        {
            OrderDetail order = new OrderDetail();
            order.Amount = 1;

            Assert.Equal(1, order.Amount);
        }

        [Fact]
        public void CanSetOrderDetailAmount()
        {
            OrderDetail order = new OrderDetail();
            order.Amount = 2;
            order.Amount = 1;

            Assert.Equal(1, order.Amount);
        }


        [Fact]
        public void CanGetOrderDetailPrice()
        {
            OrderDetail order = new OrderDetail();
            order.Price = 1;

            Assert.Equal(1, order.Price);
        }

        [Fact]
        public void CanSetOrderDetailPrice()
        {
            OrderDetail order = new OrderDetail();
            order.Price = 2;
            order.Price = 1;

            Assert.Equal(1, order.Price);
        }

        [Fact]
        public async void CanCreateCoffee()
        {
            DbContextOptions<CoffeeShopDbContext> options = new DbContextOptionsBuilder<CoffeeShopDbContext>().UseInMemoryDatabase("CanCreateCoffee").Options;
            using (CoffeeShopDbContext context = new CoffeeShopDbContext(options))
            {

                Coffee coffee = new Coffee();
                coffee.ID = 1;
                coffee.Name = "latte";
                coffee.Price = 2;
                coffee.Description = "tasty";
                coffee.URL = "www.coffee.com";

                CoffeeManager coffeeManager = new CoffeeManager(context);

                await coffeeManager.CreateCoffee(coffee);

                var result = context.Coffee.FirstOrDefault(c => c.ID == coffee.ID);

                Assert.Equal(coffee, result);
            }
        }
        [Fact]
        public async void CanDeleteCoffee()
        {
            DbContextOptions<CoffeeShopDbContext> options = new DbContextOptionsBuilder<CoffeeShopDbContext>().UseInMemoryDatabase("CanCreateCoffee").Options;
            using (CoffeeShopDbContext context = new CoffeeShopDbContext(options))
            {
                Coffee coffee = new Coffee();
                coffee.ID = 1;
                coffee.Name = "latte";
                coffee.Price = 2;
                coffee.Description = "tasty";
                coffee.URL = "www.coffee.com";

                CoffeeManager coffeeManager = new CoffeeManager(context);

                await coffeeManager.CreateCoffee(coffee);
                await coffeeManager.DeleteCoffee(1);

                var result = context.Coffee.Any(c => c.ID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public async void CanReadCoffee()
        {
            DbContextOptions<CoffeeShopDbContext> options = new DbContextOptionsBuilder<CoffeeShopDbContext>().UseInMemoryDatabase("CanCreateCoffee").Options;
            using (CoffeeShopDbContext context = new CoffeeShopDbContext(options))
            {

                Coffee coffee = new Coffee();
                coffee.ID = 1;
                coffee.Name = "latte";
                coffee.Price = 2;
                coffee.Description = "tasty";
                coffee.URL = "www.coffee.com";

                CoffeeManager coffeeManager = new CoffeeManager(context);

                await coffeeManager.CreateCoffee(coffee);
                await coffeeManager.GetCoffee(coffee.ID);

                var result = context.Coffee.FirstOrDefault(c => c.ID == coffee.ID);

                Assert.Equal(coffee, result);
            }
        }

        [Fact]
        public async void CanUpdateCoffee()
        {
            DbContextOptions<CoffeeShopDbContext> options = new DbContextOptionsBuilder<CoffeeShopDbContext>().UseInMemoryDatabase("CanCreateCoffee").Options;
            using (CoffeeShopDbContext context = new CoffeeShopDbContext(options))
            {

                Coffee coffee = new Coffee();
                coffee.ID = 1;
                coffee.Name = "latte";
                coffee.Price = 2;
                coffee.Description = "tasty";
                coffee.URL = "www.coffee.com";

                CoffeeManager coffeeManager = new CoffeeManager(context);

                await coffeeManager.CreateCoffee(coffee);
                await coffeeManager.DeleteCoffee(1);

                var result = context.Coffee.Any(c => c.ID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public void CoffeeExists()
        {
            DbContextOptions<CoffeeShopDbContext> options = new DbContextOptionsBuilder<CoffeeShopDbContext>().UseInMemoryDatabase("CanCreateCoffee").Options;
            using (CoffeeShopDbContext context = new CoffeeShopDbContext(options))
            {
                Coffee coffee = new Coffee();
                coffee.ID = 1;
                coffee.Name = "latte";
                coffee.Price = 2;
                coffee.Description = "tasty";
                coffee.URL = "www.coffee.com";

                CoffeeManager coffeeManager = new CoffeeManager(context);

                coffeeManager.CoffeeExists(1);

                var result = context.Coffee.Any(c => c.ID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public void CanGetLoginEmail()
        {
            LoginViewModel loginViewModel= new LoginViewModel();
            loginViewModel.Email = "coffee@hotmail.com";

            Assert.Equal("coffee@hotmail.com", loginViewModel.Email);
        }

        [Fact]
        public void CanSetLoginEmail()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "latte@hotmail.com";
            loginViewModel.Email = "coffee@hotmail.com";

            Assert.Equal("coffee@hotmail.com", loginViewModel.Email);
        }

        [Fact]
        public void CanGetLoginPassword()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Password = "latte123";

            Assert.Equal("latte123", loginViewModel.Password);
        }

        [Fact]
        public void CanSetLoginPassword()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Password = "123latte";
            loginViewModel.Password = "latte123";

            Assert.Equal("latte123", loginViewModel.Password);
        }

        [Fact]
        public void CanGetShoppingCart()
        {
            ShoppingCartViewModel cartvm = new ShoppingCartViewModel();
            cartvm.ShoppingCartTotal = 100;

            Assert.Equal(100, cartvm.ShoppingCartTotal);
        }

        [Fact]
        public void CanSetShoppingCart()
        {
            ShoppingCartViewModel cartvm = new ShoppingCartViewModel();
            cartvm.ShoppingCartTotal = 101;
            cartvm.ShoppingCartTotal = 100;

            Assert.Equal(100, cartvm.ShoppingCartTotal);
        }

        [Fact]
        public void CanGetViewModelFirstName()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.FirstName = "ryna";

            Assert.Equal("ryna", rvm.FirstName);
        }

        [Fact]
        public void CanSetViewModelFirstName()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.FirstName = "ray";
            rvm.FirstName = "ryna";

            Assert.Equal("ryna", rvm.FirstName);
        }

        [Fact]
        public void CanGetViewModeLastName()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.LastName = "ryna";

            Assert.Equal("ryna", rvm.FirstName);
        }

        [Fact]
        public void CanSetViewModelLastName()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.LastName = "luther";
            rvm.FirstName = "ryna";

            Assert.Equal("ryna", rvm.FirstName);
        }

        [Fact]
        public void CanGetViewModelPassword()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.Password = "ryna";

            Assert.Equal("ryna", rvm.Password);
        }

        [Fact]
        public void CanSetViewModelPassword()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.Password = "123";
            rvm.Password = "ryna";

            Assert.Equal("ryna", rvm.Password);
        }

        [Fact]
        public void CanGetViewModelFavoriteCoffee()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.FavoriteCoffee = "latte";

            Assert.Equal("latte", rvm.FavoriteCoffee);
        }

        [Fact]
        public void CanSetViewModelFavoriteCoffee()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.FavoriteCoffee = "espresso";
            rvm.FavoriteCoffee = "latte";

            Assert.Equal("latte", rvm.FavoriteCoffee);
        }








    }
}
