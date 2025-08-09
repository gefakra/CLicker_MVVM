using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;

namespace ClickerMVVM.Service
{
    public class GameService:IGameService
    {
        private readonly GameState _state;
        public IReadOnlyList<IStock> GetStocks() => _state.Stocks;
        public GameService(GameState state) => _state = state;     
        public int GetMoney() => _state.Money;
        public void AddMoney(int amount) { _state.Money += amount; }
        public bool SpendMoney(int amount)
        {
            if (_state.Money >= amount) { _state.Money -= amount; return true; }
            return false;
        }
        public int GetBonus() => 1 + _state.Stocks.Where(s => s.IsPurchased).Sum(s => s.Bonus);
        
    }
}
