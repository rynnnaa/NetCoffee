using CoffeeShop.Data;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
       
        private readonly ApplicationDbContext _user;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext user, IEmailSender emailSender) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
           
            _user = user;
            _emailSender = emailSender;
        }


        /// <summary>
        /// Default Register Page
        /// </summary>
        /// <returns>Return the View of the Register Page</returns>
        
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

                if (rvm.Email == "amanda@codefellows.com")
                {
                   
                }

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim stateClaim = new Claim("State", user.State.ToString().ToLower());

                    Claim favoriteCoffee = new Claim("FavoriteCoffee", user.FavoriteCoffee);

                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim, stateClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    if(user.Email == "amanda@codefellows.com" || user.Email == "philip.r.werner@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                        return RedirectToAction("Index", "Home");
                    }

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
                    var user = await _userManager.FindByEmailAsync(lvm.Email);
                    if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    {
                        return RedirectToAction("Index", "Admin");

                    }

                    await _emailSender.SendEmailAsync(lvm.Email, "Thank you for logging in", "<p>Thanks</p>");

                    var ourUser = await _userManager.FindByEmailAsync(lvm.Email);
                    string id = ourUser.Id;
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
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        [HttpGet]

        public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {
            // If there is an error message, send them away
            if (error != null)
            {
                // logging of the error coming in
                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }

            // see if our web app supports the login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();

            // If the web app does not support the provider, make them login with a different technique.
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // login with the external provider given the info from our sign in manager
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            // redirect them home if the login was a success
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            //get the email if this is the first time
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            //redirect to the external login page for the user to 
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });

        }

        [HttpPost]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }


                var user = new ApplicationUser()
                {
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    FirstName = elvm.firstName,
                    LastName = elvm.lastName
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    await _userManager.AddClaimAsync(user, fullNameClaim);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        // sign the user in with the information they gave us
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home");

                    }
                }


            }
            return View("ExternalLogin", elvm);
        }
    }
}