using System;

namespace Bot.Zoom
{
    class Program
    {
         static void Main(string[] args)
        {

            Product product =  ZoonmProduct.GetProduct("iphone").Result;


            Console.ReadKey();
        }
    }
}
