using Bot.Zoom.Models;
using Bot.Zoom.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Bot.Zoom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   // services.AddSingleton<IJobConfiguration, JobConfiguration>();

               });


            Console.WriteLine("Name product to search: ");
            string nameProduct = Console.ReadLine();

            string productEncode = Uri.EscapeUriString(nameProduct);

            List<Product> products = ZoonmProduct.GetProduct(productEncode).Result;

            products = products.OrderByDescending(x => x.Price).ToList();

            Console.ReadKey();
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json");

            return builder.Build();

        }

    }
}
