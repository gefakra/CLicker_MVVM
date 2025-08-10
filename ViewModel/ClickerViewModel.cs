using ClickerMVVM.Model;
using ClickerMVVM.Service.Interface;
using System.Windows.Input;

public class ClickerViewModel : ObservableObject
{
    private readonly IGameService _gameService;
    public ICommand GetMoneyCommand { get; }
    public int Money => _gameService.Money;
    public int Bonus => _gameService.BonusPerClick;

    public ClickerViewModel(IGameService gameService, GameState state)
    {
        _gameService = gameService;

        state.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(state.Money))
                OnPropertyChanged(nameof(Money));

            if (e.PropertyName == nameof(Bonus))
                OnPropertyChanged(nameof(Bonus));
        };

        GetMoneyCommand = new Command(()=>_gameService.GetBonus());
    }    
}
