using InterviewAssignment1.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAssignment1.Services
{
    public class StockService
    {
        private List<Stock> _stocks = new();
        public void Add(Stock stock)
        {
            _stocks.Add(stock);
        }

        public IEnumerable<Stock> GetAll()
        {
            return _stocks.ToArray();
        }

    }
}
