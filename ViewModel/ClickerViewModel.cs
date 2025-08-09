using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;
using System.ComponentModel;
using System.Windows.Input;

public class ClickerViewModel : INotifyPropertyChanged
{
    private readonly IGameService _gameService;
    public ICommand GetMoneyCommand { get; }
    public int Money => _gameService.GetMoney();
    public int Bonus => _gameService.GetBonus();

    public ClickerViewModel(IGameService gameService)
    {
        _gameService = gameService;
        GetMoneyCommand = new Command(GetMoney);
    }

    public void GetMoney()
    {
        _gameService.AddMoney(_gameService.GetBonus());
        OnPropertyChanged(nameof(Money));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
