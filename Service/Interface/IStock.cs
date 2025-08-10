using System.ComponentModel;

namespace ClickerMVVM.Service.Interface
{
    public interface IStock : INotifyPropertyChanged
    {
        string Name { get; }
        int Cost { get; }
        int Bonus { get; }
        bool IsPurchased { get; set; }
    }
}
