namespace ClickerMVVM
{
    public partial class ClickerPage : ContentPage
    {     
        public ClickerPage(ClickerViewModel clickerViewModel)
        {
            InitializeComponent();
            BindingContext = clickerViewModel;
        }        
    }

}
