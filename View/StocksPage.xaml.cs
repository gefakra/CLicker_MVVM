using ClickerMVVM.ViewModel;

namespace ClickerMVVM
{
	public partial class StocksPage : ContentPage
	{
		public StocksPage(StocksListViewModel stocksListViewModel)
		{
			InitializeComponent();
			BindingContext = stocksListViewModel;
		}
	}
}