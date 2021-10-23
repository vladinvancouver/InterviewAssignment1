using InterviewAssignment1.Objects;
using InterviewAssignment1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private StockService _stockService;

        public TickerController(StockService stockService)
        {
            _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            await Task.CompletedTask;

            List<DataTransfer.Stock> stocks = new();
            foreach (Stock stock in _stockService.GetAll())
            {
                stocks.Add(new()
                {
                    Symbol = stock.Symbol,
                    Price = Math.Round(stock.Price, 2)
                });
            }

            return Ok(stocks);
        }
    }
}
