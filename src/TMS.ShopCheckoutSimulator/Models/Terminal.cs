using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Terminal
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 2).ToUpper();
        private Customer Basket { get; set; }
    }
}
