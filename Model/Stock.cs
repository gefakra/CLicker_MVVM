using ClickerMVVM.Service.Interface;

namespace ClickerMVVM.Model
{
    public class Stock: ObservableObject, IStock
    {
        private bool _isPurchased;
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Bonus { get; set; }
        public bool IsPurchased 
        {
            get => _isPurchased;
            set => SetProperty(ref _isPurchased, value);
        }
    }
}
