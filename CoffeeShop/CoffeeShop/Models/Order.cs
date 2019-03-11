namespace CoffeeShop.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Order" />
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the OrderLines
        /// </summary>
        public List<OrderDetail> OrderLines { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }
    }
}
