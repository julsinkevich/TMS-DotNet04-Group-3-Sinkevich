using System;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Customer
    {
        /// <summary>
        /// Customer identification
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 3).ToUpper();
        public Customer(){}
    }
}
