using System;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using TMS.ShopCheckoutSimulator.Models;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Time of opening: {DateTime.Now}");
            ShopWork();
            //TimeOfWork();
           // BLproductsAndTotalSum();
        }
        public static void ShopWork()
        {
            Console.Write("Enter number of customers: ");
            var isCorrectNumber = int.TryParse(Console.ReadLine(), out int customersCount);
            Console.Write("Enter number of cashiers: ");
            int.TryParse(Console.ReadLine(), out int cashiersCount);

            if (isCorrectNumber)
            {
                var shop = new Shop(cashiersCount);
                for (int i = 0; i < customersCount; i++)
                {
                    shop.StartShopping();
                    //Thread.Sleep(10000);
                }
            }
        }

        private static void BLproductsAndTotalSum()
        {
            var product = new Product();
            product.AddProduct();

            var basket = new Basket(product);
            basket.AddProductInBasket();
            basket.GetSumOfBasket();

            var terminal = new Terminal(basket);
            terminal.GetTerminalInfo(15); /// add count of people
            terminal.GetSumOfTerminal();
        }
    }
}
