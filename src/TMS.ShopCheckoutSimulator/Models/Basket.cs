using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.ShopCheckoutSimulator.Models
{
    public class Basket
    {
        public Basket(Product product)
        {
            _product = product;
        }

        private Product _product;

        public IEnumerable<Product> ProductInBasket { get; set; }

        public double SumOfCheck { get; set; }

        public void AddProductInBasket()
        {
            var countProductInBasket = new Random().Next(1, 15);
            var count = 0;

            var result = new List<Product>();

            while (count != countProductInBasket)
            {
                result.Add(_product.ListOfProducts.ElementAt(new Random().Next(_product.ListOfProducts.Count())));
                count++;
            }

            ProductInBasket = result;
        }

        public void GetSumOfСheck()
        {
            foreach (var item in ProductInBasket)
            {
                SumOfCheck += item.PriceOfProduct;
            }
        }
    }
}
