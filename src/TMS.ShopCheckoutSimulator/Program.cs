using System;
using System.Collections.Generic;
using System.Threading;
using TMS.ShopCheckoutSimulator.Models;

namespace TMS.ShopCheckoutSimulator
{
    class Program
    {

        static void Main(string[] args)
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
                    Thread.Sleep(5000);
                    shop.StartShopping();
                }
            }
        }
    }
}
