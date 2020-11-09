using System;
using System.Threading;

namespace TryBefore
{
    class Program
    {

        static void Main(string[] args)
        {
            CashierManager cashierManager;

            Console.Write("Enter number of customers: ");
            int.TryParse(Console.ReadLine(), out int customersCount);

            Console.Write("Enter number of cashiers: ");//касса
            int.TryParse(Console.ReadLine(), out int cashiersCount);

            if (cashiersCount != 0)
            {
                cashierManager = new CashierManager(new Shop(cashiersCount));
            }
            else
            {
                cashierManager = new CashierManager(new Shop());
            }
            for (int i = 0; i < customersCount; i++)
            {
                cashierManager.AddCustomer(new Customer());
                Thread.Sleep(50);
            }
        }
    }
}
