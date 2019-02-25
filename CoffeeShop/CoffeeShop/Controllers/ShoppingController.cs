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

        public ShoppingController(IInventory context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

           var all = await _context.GetAllCoffee();
            return View(all);
        }

        public async Task<IActionResult> Details(int id)
        {
            var coffee = await _context.GetCoffee();
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        public IActionResult Create()
        {
            return View();
        }

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

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var coffee = await _context.GetCoffee(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Amenities/Delete/5
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
        /// Checks to see if amenity exists
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