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

        /// <summary>
        /// Price of milk before discount
        /// </summary>
        private const double _priceOfproductForSale = 2.65;

        /// <summary>
        /// Object "basket"
        /// </summary>
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
            {//;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"*********Check*************");

                foreach (var prod in item)
                {
                    if(prod.NameOfProduct.Equals("Milk"))
                    {
                        prod.PriceOfProduct = _priceOfproductForSale * 0.8;
                        Console.WriteLine("!!!!Milk discount 20%!!!!");
                    }
                    Console.WriteLine($"Product ID - { prod.Code}");
                    Console.WriteLine($"Name of product - { prod.NameOfProduct}");
                    Console.WriteLine($"Price of product - { prod.PriceOfProduct}");
                    Console.WriteLine();
                }
                Console.ResetColor();
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
            string result = String.Format("{0:C2}", TotalSumOfTerminal);
            Console.WriteLine($"Total sum - {result} BYN");
            return TotalSumOfTerminal;
        }
    }
}
