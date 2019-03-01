using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _context;
        private readonly ApplicationDbContext _user;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart context, ApplicationDbContext user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _user = user;
        }


        /// <summary>
        /// Default Register Page
        /// </summary>
        /// <returns>Return the View of the Register Page</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Our Register Action that wil succesfully create a user. 
        /// </summary>
        /// <param name="rvm"></param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //create a new Application user
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday,
                    State = rvm.State,
                    FavoriteCoffee = rvm.FavoriteCoffee
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim stateClaim = new Claim(ClaimTypes.StateOrProvince, user.State.ToString());

                    Claim favoriteCoffee = new Claim("FavoriteCoffee", user.FavoriteCoffee);

                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim, stateClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");

                }
            }
            return View(rvm);
        }
        /// <summary>
        /// Grabs the login View, and returns it back to the user. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login() => View();
        
        /// <summary>
        /// Will create a Login session for the user. 
        /// </summary>
        /// <param name="lvm"></param>
        /// <returns>View</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        /// <summary>
        /// Will succesfully sign out a user. 
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}