using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CoffeeShop.Controllers
{
    public class PolicyController : Controller
    {
        /// <summary>
        /// Returns are index page for our policies
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// You need to be authorized in order to view this page. 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Washingtonian()
        {
            return View();
        }
    }
}
