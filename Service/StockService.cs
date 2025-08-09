using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;


namespace ClickerMVVM.Service
{
    public class StockService : IStockService
    {
        public bool CanPurchase(IStock stock, int money)
            => !stock.IsPurchased && money >= stock.Cost;

        public void Purchase(IStock stock, IGameService gameService)
        {
            if (!CanPurchase(stock, gameService.GetMoney())) return;
            gameService.SpendMoney(stock.Cost);
            stock.IsPurchased = true;
        }
    }
}
