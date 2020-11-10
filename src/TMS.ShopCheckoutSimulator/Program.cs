using System;
using System.Linq;
using TMS.ShopCheckoutSimulator.Models;

namespace TMS.ShopCheckoutSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product();
            product.AddProduct();

            var basket = new Basket(product);
            basket.AddProductInBasket();
            basket.GetSumOfСheck();

            foreach (var item in basket.ProductInBasket)
            {

                Console.WriteLine(item.Code);
                Console.WriteLine(item.NameOfProduct);
                Console.WriteLine(item.PriceOfProduct);
                Console.WriteLine("------------------\n");
            }
            Console.WriteLine($"sum of check - {basket.SumOfCheck} BYN");
        }
    }
}
