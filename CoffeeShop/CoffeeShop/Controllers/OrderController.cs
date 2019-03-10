using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrder order, ShoppingCart shoppingCart)
        {
            _order = order;
            _shoppingCart = shoppingCart;
        }
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }


    }
}
