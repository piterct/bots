using Bot.Zoom.Models;
using Bot.Zoom.Models.Logs;
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
      
        private Timer _timer;

        public Service()
        {
           
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

                string productEncode = Uri.EscapeUriString(nameProduct);

                List<Product> products = ZoonmProductService.GetProduct(productEncode).Result;

                products = products.OrderByDescending(x => x.Price).ToList();

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
