using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMS.ShopCheckoutSimulator.Models
{
    public class Product
    {
        public string Code { get; set; }

        public string NameOfProduct { get; set; }

        public double PriceOfProduct { get; set; }

        public List<Product> ListOfProducts { get; set; }

        public override string ToString()
        {
            return Code = Guid.NewGuid().ToString().Substring(0,5).ToUpper();
        }

        public List<Product> AddProduct()
        {
            ListOfProducts = new List<Product>
            {
                new Product
                {
                    NameOfProduct = "Milk",
                    PriceOfProduct = 2.65,
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Bread",
                    PriceOfProduct = 3.41,
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Apple",
                    PriceOfProduct = 5.63,
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Meat",
                    PriceOfProduct = 55.63,
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Chocolate",
                    PriceOfProduct = 16.63,
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Clothes",
                    PriceOfProduct = new Random().Next(146, 210),
                    Code = ToString()
                },

                new Product
                {
                    NameOfProduct = "Fish",
                    PriceOfProduct = 38.5,
                    Code = ToString()
                }
            };

            return ListOfProducts;
        }
    }
}