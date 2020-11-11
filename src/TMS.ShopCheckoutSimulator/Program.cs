using System;
using System.ComponentModel;
using System.Linq;
using TMS.ShopCheckoutSimulator.Models;

namespace TMS.ShopCheckoutSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            BLproductsAndTotalSum();
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
