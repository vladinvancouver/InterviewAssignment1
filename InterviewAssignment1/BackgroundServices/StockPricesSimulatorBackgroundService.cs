using InterviewAssignment1.Objects;
using InterviewAssignment1.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewAssignment1.BackgroundServices
{
    public class StockPricesSimulatorBackgroundService : BackgroundService
    {
        private StockService _stockService;
        private Random _random = new();

        public StockPricesSimulatorBackgroundService(StockService stockService)
        {
            _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    foreach (Stock stock in _stockService.GetAll())
                    {
                        decimal percent = _random.Next(-10, 11) / 100m;
                        stock.Price += stock.Price * percent;
                    }

                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                    catch { }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
