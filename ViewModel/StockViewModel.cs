using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ClickerMVVM.ViewModel
{
    public class StockViewModel : INotifyPropertyChanged
    {
        private readonly IStockService _stockService;
        private readonly IGameService _gameService;
        private readonly IStock _stock;

        public string Name => _stock.Name;
        public int Cost => _stock.Cost;
        public int Bonus => _stock.Bonus;
        public bool IsPurchased => _stock.IsPurchased;

        public StockViewModel(IStock stock, IGameService gameService, IStockService stockService)
        {
            _stock = stock;
            _gameService = gameService;
            _stockService = stockService;
        }

        public void Purchase()
        {
            _stockService.Purchase(_stock, _gameService);
            OnPropertyChanged(nameof(IsPurchased));
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
