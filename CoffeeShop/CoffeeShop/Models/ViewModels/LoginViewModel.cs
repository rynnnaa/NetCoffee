namespace CoffeeShop.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="LoginViewModel" />
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
