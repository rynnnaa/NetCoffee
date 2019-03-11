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
    public class IndexModel : PageModel
    {

        private readonly IInventory _inventory;

        public IndexModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        [FromRoute]
        public int ID { get; set; }
        public Coffee coffee { get; set; }


        public async Task OnGet()
        {
             var inventory = await _inventory.GetCoffee(ID);
        }
    }
}