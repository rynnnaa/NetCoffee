namespace CoffeeShop.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    /// <summary>
    /// Defines the <see cref="ApplicationUser" />
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Birthday
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether State is true or false
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// Gets or sets the FavoriteCoffee
        /// </summary>
        public string FavoriteCoffee { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
    }
}
