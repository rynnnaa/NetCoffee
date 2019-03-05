using CoffeeShop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public static string Member { get; internal set; }
        public static string Admin { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public State State { get; set; }
        public string FavoriteCoffee { get; set; }

        
    }
}
