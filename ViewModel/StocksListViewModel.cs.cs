using ClickerMVVM.Service.Interface;

namespace ClickerMVVM.ViewModel
{
    public class StocksListViewModel
    {
        public List<StockViewModel> Stocks { get; }

        public StocksListViewModel(IGameService gameService, IStockService stockService)
        {
            Stocks = gameService
            .Stocks
            .Select(stock => new StockViewModel(stock, gameService))
            .ToList();
        }
    }
}
