namespace CoffeeShop.Models
{
    /// <summary>
    /// Defines the <see cref="OrderDetail" />
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// Gets or sets the OrderDetailId
        /// </summary>
        public int OrderDetailId { get; set; }

        /// <summary>
        /// Gets or sets the OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the CoffeeId
        /// </summary>
        public int CoffeeId { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Coffee
        /// </summary>
        public Coffee Coffee { get; set; }

        /// <summary>
        /// Gets or sets the Order
        /// </summary>
        public Order Order { get; set; }
    }
}
