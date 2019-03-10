namespace CoffeeShop.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="RegisterViewModel" />
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Birthday
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmPassword
        /// </summary>
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether State
        /// </summary>
        [Required]
        [Display(Name = "Are you from the state of Washington?")]
        public bool State { get; set; }

        /// <summary>
        /// Gets or sets the FavoriteCoffee
        /// </summary>
        [Required]
        public string FavoriteCoffee { get; set; }
    }
}
