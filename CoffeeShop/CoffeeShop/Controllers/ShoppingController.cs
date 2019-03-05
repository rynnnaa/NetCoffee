using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class ShoppingController : Controller
    {
        private IInventory _context;

        /// <summary>
        /// Constructor that grabs are db context. 
        /// </summary>
        /// <param name="context"></param>
        public ShoppingController(IInventory context) 
        {
            _context = context;
        }
        /// <summary>
        /// Will Return all Coffee objects from our database
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {

            var all = await _context.GetAllCoffee();
            return View(all);
        }
        /// <summary>
        /// Will return details for a specific coffee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Detils for one Coffee</returns>
        public async Task<IActionResult> Details(int id)
        {
            var coffee = await _context.GetCoffee(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }
        /// <summary>
        /// Will return view to create a new coffee
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new Coffee object
        /// </summary>
        /// <param name="coffee"></param>
        /// <returns>View for indivdual coffee</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {

                await _context.CreateCoffee(coffee);
                return RedirectToAction(nameof(Index));
            }
            return View(coffee);
        }

       /// <summary>
       /// Will bring you to the coffee view
       /// <param name="id"></param>
       /// <returns>View for individual coffee</returns>
        public async Task<IActionResult> Edit(int id)
        {

            var coffee = await _context.GetCoffee(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        /// <summary>
        /// Allows you to edit a coffee object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="coffee"></param>
        /// <returns>Coffee Object</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Coffee coffee)
        {
            if (id != coffee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _context.CreateCoffee(coffee);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(coffee);
        }

        /// <summary>
        /// Displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view</returns>
        public async Task<IActionResult> Delete(int id)
        {

            var coffee = await _context.GetCoffee(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        /// <summary>
        /// Deleting one instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletion</returns>
        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffees = await _context.GetCoffee(id);
            await _context.DeleteCoffee(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks to see if  exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CoffeeExists(int id)
        {
            if (_context.GetCoffee(id) != null)
            {
                return false;
            }
            return true;
        }
    }
}