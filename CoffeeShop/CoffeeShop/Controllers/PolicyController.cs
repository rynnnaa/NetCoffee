using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CoffeeShop.Controllers
{
    [Authorize(Policy = "Seattleite")]
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Seattlelite()
        {
            return View();
        }
    }
}
