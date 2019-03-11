using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeShop.Views.Pages.Admin
{
    public class ManageModel : PageModel
    {
        private readonly IInventory _coffee;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Coffee coffee { get; set; }

        public ManageModel(IInventory coffee)
        {
            _coffee = coffee;
        }

        public async Task OnGet()
        {
            Coffee coffee = await _coffee.GetCoffee(ID.GetValueOrDefault()) ?? new Coffee();
        }

        public async Task<IActionResult> OnPost()
        {
            // Make the call to our DB with our ID.
            var cof = await _coffee.GetCoffee(ID.GetValueOrDefault()) ?? new Coffee();

            // set the data from the database to the new data from Restaurant/user input
            cof.Name = coffee.Name;
            cof.Description = coffee.Description;
            cof.Price = coffee.Price;

            // Save the restaurant in the database
         

            return RedirectToPage("/CoffeeShop/Index", new { id = cof.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _coffee.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}