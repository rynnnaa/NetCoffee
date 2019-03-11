namespace CoffeeShop.Models.ViewModels
{
    /// <summary>
    /// Defines the <see cref="ShoppingCartViewModel" />
    /// </summary>
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// Gets or sets the ShoppingCart
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartTotal
        /// </summary>
        public decimal ShoppingCartTotal { get; set; }
    }
}
