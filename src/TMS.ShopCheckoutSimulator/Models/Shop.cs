﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TMS.ShopCheckoutSimulator.Models
{
    class Shop
    {
        public string Name { get; set; }
        public int TerminalCount { get; set; }

        public static SemaphoreSlim Terminals { get; set; }

        public Thread TerminalsThread { get; set; }

        public Shop()
        {
            Name = "Соседи";
            TerminalCount = 1;
            Terminals = new SemaphoreSlim(1, 1);
        }
        public Shop(int termialsCount)
        {
            Name = "Соседи";
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
            var time = random.Next(1000, 3777);
            var customer = new Customer();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{customer.Id} пришёл в магазин. Число свободных касс: {Terminals.CurrentCount}");
            Console.ResetColor();
            Thread.Sleep(time);

            Terminals.Wait();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{customer.Id} стал в очередь.");
            Console.ResetColor();
            Thread.Sleep(time);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{customer.Id} купил, т.е список продуктов: ");
            Console.ResetColor();
            Thread.Sleep(time);

            Terminals.Release();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Число свободных касс: {Terminals.CurrentCount}. {customer.Id} ушёл из магазина");
            Console.ResetColor();
        }
    }
}