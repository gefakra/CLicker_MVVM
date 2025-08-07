using ClickerMVVM.Model;
using System.ComponentModel;
using System.Windows.Input;

public class ClickerViewModel : INotifyPropertyChanged
{
    private readonly GameState _state;    
    public int Money=> _state.Money;
    public ICommand GetMoneyCommand { get; }

    public ClickerViewModel(GameState state)
    {
        _state = state;

        _state.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(GameState.Money))
                OnPropertyChanged(nameof(Money));
        };

        GetMoneyCommand = new Command(() =>
        {
            _state.Money += _state.GetBonus();
        });
            
    }   

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
