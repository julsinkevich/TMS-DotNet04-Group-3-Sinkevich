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

        /// <summary>
        /// Products in the basket
        /// </summary>
        public IEnumerable<Product> ProductInBasket { get; set; }

        /// <summary>
        /// Sum Of Check In  the Basket (only)
        /// </summary>
        public double SumOfCheckInBasket { get; set; }

        public IEnumerable<Product> AddProductInBasket()
        {
            var countProductInBasket = new Random().Next(1, 15);
            var count = 0;
            var result = new List<Product>();

            while (count != countProductInBasket)
            {
                result.Add(_product.ListOfProducts
                    .ElementAt(new Random()
                    .Next(_product.ListOfProducts
                    .Count())));
                count++;
            }
            ProductInBasket = result;

            return ProductInBasket;
        }

        public double GetSumOfBasket()
        {
            return SumOfCheckInBasket = ProductInBasket
                .Aggregate(0.0, (current, next) => current += next.PriceOfProduct);
        }
    }
}
