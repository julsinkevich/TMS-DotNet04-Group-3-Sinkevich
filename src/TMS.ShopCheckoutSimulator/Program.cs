using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TMS.ShopCheckoutSimulator.Models
{
    internal class Program
    {
        private static List<Thread> threads = new List<Thread>();

        private static void Main(string[] args)
        {
            const string open = "Opening...\n";
            foreach (char c in open)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(c);
                Thread.Sleep(500);
                Console.ResetColor();
            }
            Console.WriteLine($"Time of opening: {DateTime.Now}");
            TimeOfWork();

            Console.ReadKey();
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
            Console.WriteLine($"Time of work {elapsedTime}. Closing time: {DateTime.Now} ");
        }

        public static void ShopWork()
        {
            Console.Write("Enter number of customers: ");
            var isCorrectNumber = int.TryParse(Console.ReadLine(), out int customersCount);

            Console.Write("Enter number of cashiers: ");
            int.TryParse(Console.ReadLine(), out int cashiersCount);

            if (isCorrectNumber)
            {
                var shop = new SupermarketManager(cashiersCount);
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
            const string open = "...Closing\n";
            foreach (char c in open)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(c);
                Thread.Sleep(500);
                Console.ResetColor();
            }
        }
    }
}
