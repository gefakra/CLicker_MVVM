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
            if (!CanPurchase(stock, gameService.Money)) return;
            if (gameService.BuyStock(stock))
            {
                stock.IsPurchased = true;
            }
        }
    }
}
