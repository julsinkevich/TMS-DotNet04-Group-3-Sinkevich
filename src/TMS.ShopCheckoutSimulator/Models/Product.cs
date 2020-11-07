using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Product
    {
        public string Code { get; set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return Code;
        }
    }
}
