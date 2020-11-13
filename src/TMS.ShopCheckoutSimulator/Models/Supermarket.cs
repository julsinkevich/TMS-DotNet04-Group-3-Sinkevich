using System;
using System.Diagnostics;
using System.Threading;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Supermarket
    {
        public string Name { get; set; }
        public int TerminalCount { get; set; }
        public static SemaphoreSlim Terminals { get; set; }
        public Thread TerminalsThread { get; set; }
        public Supermarket()
        {
            Name = "Supermarket";
            TerminalCount = 1;
            Terminals = new SemaphoreSlim(1, 1);
        }
        public Supermarket(int termialsCount)
        {
            Name = "Supermarket";
            TerminalCount = termialsCount;
            Terminals = new SemaphoreSlim(termialsCount, termialsCount);
        }
        public void StartShopping()
        {
            TerminalsThread = new Thread(DoShopping);
            TerminalsThread.Start();
        }
        public void DoShopping()
        {
            var random = new Random();
            var time = random.Next(1000, 3200);
            var customer = new Customer();

            var product = new Product();
            product.AddProduct();

            var basket = new Basket(product);
            basket.AddProductInBasket();
            basket.GetSumOfBasket();

            var terminal = new Terminal(basket);

            Thread.Sleep(time);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The customer {customer.Id} came to the store.      Number of free terminals: {Terminals.CurrentCount}");
            Console.ResetColor();
            Thread.Sleep(time);

            Terminals.Wait();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The customer {customer.Id} stood in line.");
            Console.ResetColor();
            Thread.Sleep(time);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"The customer {customer.Id} bought: ");
            terminal.GetTerminalInfo(1);
            terminal.GetSumOfTerminal();
            Console.ResetColor();
            Thread.Sleep(time);

            Terminals.Release();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Number of free terminals: {Terminals.CurrentCount}.             The customer {customer.Id} left.");
            Console.ResetColor();
        }
    }
}
