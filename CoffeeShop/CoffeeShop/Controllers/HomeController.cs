using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Returns our Shared Layout Page
        /// </summary>
        /// <returns>View</returns>
        /// 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(bool works = true)
        //{
        //    Payment payment = new Payment(_configuration);
        //    string answer = payment.Run();

        //    if(answer == "OK")
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //    return View();

        //    }
        //}
    }
}
