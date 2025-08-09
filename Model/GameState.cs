using ClickerMVVM.Service.Interface;
using System.ComponentModel;

namespace ClickerMVVM.Model
{
    public class GameState : INotifyPropertyChanged
    {

        private int _money;
        private List<IStock> _Stocks;
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
        public List<IStock> Stocks
        {
            get=> _Stocks; 
            set
            { 
                _Stocks = value;
                OnPropertyChanged(nameof(Stocks)); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
