﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Zoom
{
    class Program
    {
         static void Main(string[] args)
        {

            List<Product> products =  ZoonmProduct.GetProduct("iphone").Result;

            products = products.OrderByDescending(x => x.Price).ToList();

            Console.ReadKey();
        }
    }
}
