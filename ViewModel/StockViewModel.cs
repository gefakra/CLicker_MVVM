using ClickerMVVM.Service.Interface;
using System.ComponentModel;
using System.Windows.Input;

namespace ClickerMVVM.ViewModel
{
    public class StockViewModel : ObservableObject
    {
        private readonly IStockService _stockService;
        private readonly IGameService _gameService;
        private readonly IStock _stock;
        public ICommand PurchaseCommand { get; }
        public string Name => _stock.Name;
        public int Cost => _stock.Cost;
        public int Bonus => _stock.Bonus;
        public bool IsPurchased => _stock.IsPurchased;

        public StockViewModel(IStock stock, IGameService gameService)
        {
            _stock = stock;
            _gameService = gameService;

            _stock.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(_stock.IsPurchased))
                    OnPropertyChanged(nameof(IsPurchased));
            };

            PurchaseCommand = new Command(
                execute: () =>
                    {
                        if (_gameService.BuyStock(_stock))
                            OnPropertyChanged(nameof(IsPurchased));
                    },
                    canExecute: () => !_stock.IsPurchased && _gameService.Money >= _stock.Cost);

            _stock.PropertyChanged += (_, __) =>
            {
                OnPropertyChanged(nameof(IsPurchased));
                ((Command)PurchaseCommand).ChangeCanExecute();
            };

            if (_gameService is INotifyPropertyChanged notifyGameService)
            {
                notifyGameService.PropertyChanged += (_, __) =>
                {
                    ((Command)PurchaseCommand).ChangeCanExecute();
                };
            }

        }

    }
}
