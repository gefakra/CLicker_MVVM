using ClickerMVVM.Service;
using ClickerMVVM.Service.Interface;
using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace ClickerMVVM.ViewModel
{
    public class StatsViewModel : INotifyPropertyChanged
    {
        private readonly IGameService _gameService;
        public int TotalMoney => _gameService.GetMoney();
        public int BonusPerClick => _gameService.GetBonus();        

        public StatsViewModel(IGameService gameService)
        {
            _gameService = gameService;
            //if (_gameService is GameService gs)
            //{
            //    gs.GetStocks().ToList().ForEach(s =>
            //    {
            //        if (s is INotifyPropertyChanged npc)
            //            npc.PropertyChanged += (_, __) => OnPropertyChanged(nameof(BonusPerClick));
            //    });
            //}

            (gameService.GetStocks() as IEnumerable<INotifyPropertyChanged>)?
                .ToList()
                .ForEach(s => s.PropertyChanged += (_, __) => OnPropertyChanged(nameof(BonusPerClick)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
