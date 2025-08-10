using ClickerMVVM.Service.Interface;
using System.Collections.ObjectModel;

namespace ClickerMVVM.Model
{
    public class GameState : ObservableObject
    {
        private int _money;        
        public int Money
        {
            get => _money;
            set => SetProperty(ref _money, value);            
        }
        public ObservableCollection<IStock> Stocks { get; }
       

        public GameState()
        {
            Stocks = new ObservableCollection<IStock>()
            {
                new Stock { Name = "Tech Stock", Cost = 10, Bonus = 5 },
                new Stock { Name = "Energy Stock", Cost = 30, Bonus = 10 },
                new Stock { Name = "Startup Stock", Cost = 5, Bonus = 2 }
            };
        }
    }
}
