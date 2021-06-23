using Bot.Zoom.Interfaces;
using Bot.Zoom.Models;
using Bot.Zoom.Models.LogsModel;
using Bot.Zoom.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Bot.Zoom
{
    public class Service : IHostedService, IDisposable
    {
        private readonly IProductRepository _productRepository;
        private Timer _timer;

        public Service(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            ExecuteBot();

            // _timer = new Timer(
            //(e) => ExecuteCustomer(),
            //null,
            //TimeSpan.Zero,
            //TimeSpan.FromMinutes(Convert.ToDouble(_jobConfiguration.ExecuteInterval)));

            return Task.CompletedTask;

        }

        private async void ExecuteBot()
        {
            try
            {
                Console.WriteLine("Name product to search: ");
                string nameProduct = Console.ReadLine();

                List<Product> products = ZoonmProductService.GetProduct(nameProduct).Result;

                products = products.OrderByDescending(x => x.Price).ToList();
                await _productRepository.InsertProducts(products);

                if (products.Count == 1)
                    Console.WriteLine(string.Format("{0} {1}", products.Count, "product was found"));
                else
                {
                    Console.WriteLine(string.Format("{0} {1}", products.Count, "produts were found"));
                }

                Console.WriteLine(string.Format("{0} {1}", "The cheapest product costs BRL", products.OrderBy(x => x.Price).FirstOrDefault().Price));
                Console.WriteLine(string.Format("{0} {1}", "The more expensive product costs BRL", products.OrderByDescending(x => x.Price).FirstOrDefault().Price));

                Console.ReadKey();
            }

            catch (Exception ex)
            {

                new LogJobErrorModel
                {
                    Message = ex.Message,
                    Area = "Execute Bot",
                    Date = DateTime.Now,
                    TypeException = ex.GetType().Name,
                    StackTrace = ex.StackTrace
                };

            }

            finally
            {
                new LogJobModel { Message = "Bot Finished", Area = "Execute Bot", Date = DateTime.Now };
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
