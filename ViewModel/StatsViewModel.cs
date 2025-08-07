using ClickerMVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickerMVVM.ViewModel
{
    public class StatsViewModel : INotifyPropertyChanged
    {
        private readonly GameState _state;

        public int TotalMoney => _state.Money;
        public int BonusPerClick => _state.GetBonus();

        public StatsViewModel(GameState state)
        {
            _state = state;
            _state.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(GameState.Money))
                {
                    OnPropertyChanged(nameof(TotalMoney));
                    OnPropertyChanged(nameof(BonusPerClick));
                }
            };

            _state.Stocks.CollectionChanged += (_, _) =>
            {
                OnPropertyChanged(nameof(BonusPerClick));
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
