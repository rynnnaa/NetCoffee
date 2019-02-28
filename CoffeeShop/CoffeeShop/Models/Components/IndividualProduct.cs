﻿using CoffeeShop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Components
{
    public class IndividualProduct : ViewComponent
    {
        private Data.CoffeeShopDbContext _context;

        public IndividualProduct(CoffeeShopDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var coffee = _context.Coffee.OrderBy(a => a.ID)
                .ToList();
            return View(coffee);
        }
    }
}