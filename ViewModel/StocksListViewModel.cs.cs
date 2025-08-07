using ClickerMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerMVVM.ViewModel
{
    public class StocksListViewModel
    {
        public ObservableCollection<StockViewModel> Stocks { get; }

        public StocksListViewModel(GameState state)
        {
            Stocks = new ObservableCollection<StockViewModel>(
                state.Stocks.Select(stock => new StockViewModel(state, stock)));
        }
    }
}
