using System;
using System.Collections.Generic;

namespace TryBefore
{
    class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 3).ToUpper();
        private List<Product> Products { get; set; }

        public Customer()
        {
            Console.WriteLine($"Customer found: {Id}.");
        }
        public Customer(int check)
        {
            Console.WriteLine($"Customer found: {Id}, list of products in the basket: {check} .");
            //здесь + чек
        }
    }
}