using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;
using System.Collections.ObjectModel;

namespace ClickerMVVM.Service
{
    public class GameService : IGameService
    {
        private readonly GameState _state;
        public int Money => _state.Money;
        public int BonusPerClick => 1 + _state.Stocks.Where(s => s.IsPurchased).Sum(s => s.Bonus);
        public ObservableCollection<IStock> Stocks => _state.Stocks;
        public GameService(GameState state) => _state = state; 
        public int GetBonus() => _state.Money += BonusPerClick;
        public bool BuyStock(IStock stock)
        {
            if (!stock.IsPurchased && _state.Money >= stock.Cost)
            {
                _state.Money -= stock.Cost;
                stock.IsPurchased = true;
                return true;
            }
            return false;
        }


    }
}
