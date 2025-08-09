using ClickerMVVM.Model;

namespace ClickerMVVM.Service.Interface
{
    public interface IStockService
    {
        bool CanPurchase(IStock stock, int money);
        void Purchase(IStock stock, IGameService gameService);
    }
}
