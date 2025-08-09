using ClickerMVVM.Model;
using ClickerMVVM.Service;
using ClickerMVVM.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerMVVM.ViewModel
{
    public class StocksListViewModel
    {
        public List<StockViewModel> Stocks { get; }

        public StocksListViewModel(IGameService gameService, IStockService stockService)
        {
            Stocks = gameService
            .GetStocks()
            .Select(stock => new StockViewModel(stock, gameService, stockService))
            .ToList();
        }
    }
}
