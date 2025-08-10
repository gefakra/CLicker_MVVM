using ClickerMVVM.ViewModel;

namespace ClickerMVVM
{
	public partial class StatsPage : ContentPage
	{
		public StatsPage(StatsViewModel statsViewModel)
		{
			InitializeComponent();
			BindingContext = statsViewModel;

		}
	}
}