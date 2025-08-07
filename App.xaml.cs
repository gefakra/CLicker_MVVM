using Clicker_MVVM;

namespace ClickerMVVM
{
    public partial class App : Application
    {
        public App(ClickerPage clicker, StatsPage stats, StocksPage stocks)
        {
            InitializeComponent();

            MainPage = new AppShell
            {
                Items =
                {
                    new ShellContent { Title = "Clicker", Content = clicker },
                    new ShellContent { Title = "Stats", Content = stats },
                    new ShellContent { Title = "Stocks", Content = stocks }
                }
            };
        }
    }
}
