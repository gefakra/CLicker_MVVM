
using ClickerMVVM.Service.Interface;

namespace ClickerMVVM.Model
{
    public class Stock: IStock
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Bonus { get; set; }
        public bool IsPurchased { get; set; }
    }
}
