using System.Collections.ObjectModel;

namespace ClickerMVVM.Service.Interface
{
    public interface IGameService
    {
        int Money { get; }
        int BonusPerClick { get; }
        ObservableCollection<IStock> Stocks { get; }
        int GetBonus();
        bool BuyStock(IStock stock);
    }
}
