using ClickerMVVM.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClickerMVVM.ViewModel
{
    public class StockViewModel : INotifyPropertyChanged
    {
        private readonly GameState _state;
        private readonly Stock _stock;
        public string Name => _stock.Name;
        public int Cost => _stock.Cost;
        public int Bonus => _stock.Bonus;
        public bool IsPurchased => _stock.IsPurchased;

        public ICommand PurchaseCommand { get; }

        public StockViewModel(GameState state, Stock stock)
        {
            _state = state;
            _stock = stock;

            PurchaseCommand = new Command(ExecutePurchase, CanPurchase);

            _state.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(GameState.Money))
                {
                    (PurchaseCommand as Command)?.ChangeCanExecute();
                }
            };

        }

        private bool CanPurchase() => !_stock.IsPurchased && _state.Money >= _stock.Cost;

        private void ExecutePurchase()
        {
            if (!CanPurchase()) return;

            _state.Money -= _stock.Cost;
            _stock.IsPurchased = true;

            OnPropertyChanged(nameof(IsPurchased));
            (PurchaseCommand as Command)?.ChangeCanExecute();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
