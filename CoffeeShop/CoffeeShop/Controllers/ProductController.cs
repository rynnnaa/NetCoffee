using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _context;
        private readonly ApplicationDbContext _user;
        private readonly CoffeeShopDbContext _coffee;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProduct context, ApplicationDbContext user, CoffeeShopDbContext coffee, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _user = user;
            _coffee = coffee;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable product = await _context.GetAllProducts();
            return View(product);
        }
        
        [HttpPost] 
        public async Task<IActionResult> Create (int productID, string userId, int quantity)
        {
            ApplicationUser user = await _user.Users.FirstOrDefaultAsync(use => use.Id == userId);

            Cart userCart = await _coffee.Carts.FirstOrDefaultAsync(u => u.Taken == false && u.UserID == userId);

            var product = await _context.GetAProduct(productID);

            product = new Product()
            {
                ProductID = productID,
                CartID = userCart.ID,
                Quantity = quantity,
            };

            await _context.CreateProduct(product);

            return RedirectToAction("Index", "Coffee");

        } 
    }
}
