using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IInventory _inventory;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IInventory inventory, ShoppingCart shoppingCart)
        {
            _inventory = inventory;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var cartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotal()
            };
            return View(cartViewModel);
        }

        
        public async Task <RedirectToActionResult> AddToShoppingCart(int id)
        {
            Coffee selected = await _inventory.GetCoffee(id);

            if (selected != null)
            {
                _shoppingCart.AddToCart(selected, 1);
            }
            return RedirectToAction("Index");
        }

        public async Task <RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            Coffee selected = await _inventory.GetCoffee(id);

            if (selected != null)
            {
                _shoppingCart.RemoveFromCart(selected);
            }
            return RedirectToAction("Index");
        }
    }
}


