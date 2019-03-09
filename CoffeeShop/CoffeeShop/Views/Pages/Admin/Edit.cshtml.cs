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
    public class EditModel : PageModel
    {

        private readonly IInventory _inventory;

        public EditModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        [FromRoute]
        public int ID { get; set; }
        public Coffee coffee{ get; set; }


        public async Task OnGet()
        {
            Coffee = await _inventory.FindCoffee(ID);
        }
    }
}