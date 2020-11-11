using System;
using System.Collections.Generic;
using System.Threading;
using TMS.ShopCheckoutSimulator.Models;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace ShopCheckoutSimulator
{
    class Program
    {

        public static DateTime TimeOfOpen = DateTime.Now;

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
            Console.WriteLine($"Time of opening: {TimeOfOpen}");
            TimeOfWork();
        }

        public static void TimeOfWork()
        {

            Stopwatch workTime = new Stopwatch();
            workTime.Start();
            Thread.Sleep(5000);
            workTime.Stop();
            TimeSpan ts = workTime.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"Time of work {elapsedTime}");
            Console.WriteLine($"Closing time: {DateTime.Now}");

            Console.ReadKey();
        }
    }
}
