using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;
using System.ComponentModel;

namespace ClickerMVVM.ViewModel
{
    public class StatsViewModel : ObservableObject
    {
        private readonly IGameService _gameService;
        private readonly GameState _state;
        public int TotalMoney => _state.Money;
        public int BonusPerClick => _gameService.BonusPerClick;

        public StatsViewModel(IGameService gameService,GameState state)
        {
            _gameService = gameService;
            _state = state;

            _state.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_state.Money))
                    OnPropertyChanged(nameof(TotalMoney));
            };

            (gameService.Stocks as IEnumerable<INotifyPropertyChanged>)?
                .ToList()
                .ForEach(s => s.PropertyChanged += (_, __) => OnPropertyChanged(nameof(BonusPerClick)));
        }
    }
}
