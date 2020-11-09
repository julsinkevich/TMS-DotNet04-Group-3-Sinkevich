using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TryBefore
{
    class CashierManager
    {
        private readonly Shop shops;
        private static Object locker = new Object();

        public CashierManager(Shop shop)
        {
            shops = shop;
        }
        public void AddCustomer(Customer customer)
        {
            Thread thread = new Thread(DoShopping);
            thread.Start(customer);
        }
        public void DoShopping(Object person)
        {
            var random = new Random();
            var time = random.Next(500, 1500);
            if (!(person is Customer))
            {
                throw new ArgumentException();
            }
            var customer = (Customer)person;
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{customer.Id} пришёл в магазин.");
                Console.ResetColor();
            }
            Thread.Sleep(time);
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{customer.Id} стал в очередь № кассы ");
                Console.ResetColor();
            }
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{customer.Id} купил, т.е список продуктов и в какой кассе (в каком потоке) ");
                Console.ResetColor();
            }
            Thread.Sleep(time);
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{customer.Id} ушёл из магазина");
                Console.ResetColor();
            }
        }

    }
}
