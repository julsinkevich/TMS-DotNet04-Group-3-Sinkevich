using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Program
    {
        private static List<Thread> threads = new List<Thread>();

        static void Main(string[] args)
        {
            Console.WriteLine($"Time of opening: {DateTime.Now}");
            TimeOfWork();
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
                    threads.Add(shop.TerminalsThread);
                    Thread.Sleep(5000);
                }
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("gdbg");
        }
        public static void TimeOfWork()
        {

            Stopwatch workTime = new Stopwatch();
            workTime.Start();
            ShopWork();
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
