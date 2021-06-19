using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Bot.Zoom
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Name product to search: ");
            string nameProduct = Console.ReadLine();

            string productEncode = Uri.EscapeUriString(nameProduct);

            List<Product> products = ZoonmProduct.GetProduct(productEncode).Result;

            products = products.OrderByDescending(x => x.Price).ToList();

            Console.ReadKey();
        }
    }
}
