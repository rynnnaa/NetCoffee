namespace CoffeeShop.Models
{
    /// <summary>
    /// Defines the <see cref="ShoppingCartItem" />
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// Gets or sets the ShoppingCartItemId
        /// </summary>
        public int ShoppingCartItemId { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingCartId
        /// </summary>
        public string ShoppingCartId { get; set; }

        // Nav prop
        /// <summary>
        /// Gets or sets the Coffee
        /// </summary>
        public Coffee Coffee { get; set; }
    }
}
