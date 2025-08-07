using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ClickerMVVM.Model
{
    public class GameState : INotifyPropertyChanged
    {
        private int _money;
        public int Money
        {
            get => _money;
            set
            {
                if (_money != value)
                {
                    _money = value;
                    OnPropertyChanged(nameof(Money));
                }
            }
        }
        public int GetBonus() =>
        1 + Stocks.Where(s => s.IsPurchased).Sum(s => s.Bonus);

        public ObservableCollection<Stock> Stocks { get; set; } =
            new()
            {
                new Stock { Name = "Tech Stock", Cost = 10, Bonus = 5 },
                new Stock { Name = "Energy Stock", Cost = 30, Bonus = 10 },
                new Stock { Name = "Startup Stock", Cost = 5, Bonus = 2 }
            };

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
