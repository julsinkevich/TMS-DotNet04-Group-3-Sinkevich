using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Terminal
    {
        public Terminal(Basket basket)
        {
            _basket = basket;
        }

        private Basket _basket;

        /// <summary>
        /// Products in each person's basket
        /// </summary>
        public ICollection<List<Product>> CollectionOfProductForPeople { get; set; }

        /// <summary>
        /// TotalSumOfTerminal
        /// </summary>
        public double TotalSumOfTerminal { get; set; }

        public void GetTerminalInfo(int counOfPeople)
        {
            var counter = 0;
            CollectionOfProductForPeople = new List<List<Product>>();

            while (counter != counOfPeople)
            {
                var result = _basket.AddProductInBasket();
                CollectionOfProductForPeople.Add(result.ToList());
                counter++;
            }

            foreach (var item in CollectionOfProductForPeople)
            {;
                Console.WriteLine($"Чек");

                foreach (var prod in item)
                {
                    Console.WriteLine($"Product ID - { prod.Code}");
                    Console.WriteLine($"Name of product - { prod.NameOfProduct}");
                    Console.WriteLine($"Price of product - { prod.PriceOfProduct}");
                    Console.WriteLine();
                }
            }
        }

        public double GetSumOfTerminal()
        {
            foreach (var item in CollectionOfProductForPeople)
            {
                foreach (var prod in item)
                {
                    TotalSumOfTerminal += prod.PriceOfProduct;
                }
            }

            Console.WriteLine($"Total sum - {TotalSumOfTerminal} BYN");
            return TotalSumOfTerminal;
        }
    }
}
