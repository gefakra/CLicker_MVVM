# 🖱️ ClickerMVVM

**ClickerMVVM** — это простое кликер-приложение, реализованное с использованием паттерна **MVVM (Model-View-ViewModel)** в .NET MAUI.

## 🧩 Архитектура

Проект разделён на три уровня:
- **Model** — данные и состояние игры.
- **ViewModel** — логика, связывающая данные и представление.
- **View (Pages)** — пользовательский интерфейс.

```
📦 ClickerMVVM
├── Models
│   ├── GameState.cs
│   └── Stock.cs
├── ViewModels
│   ├── ClickerViewModel.cs
│   ├── StatsViewModel.cs
│   ├── StockViewModel.cs
│   └── StocksListViewModel.cs
├── Views
│   ├── ClickerPage.xaml
│   ├── StatsPage.xaml
│   └── StocksPage.xaml
└── MauiProgram.cs
```

## 🧠 Model

### `GameState`
- Хранит текущее состояние игры: деньги (`Money`) и список акций (`Stocks`).
- Реализует `INotifyPropertyChanged`.
- Метод `GetBonus()` возвращает суммарный бонус всех купленных акций.

### `Stock`
- Модель отдельной акции: `Name`, `Cost`, `Bonus`, `IsPurchased`.

## 🧠 ViewModel

### `ClickerViewModel`
- Обрабатывает логику кнопки **"Get Money"**.
- `GetMoneyCommand` увеличивает деньги на текущий бонус.

### `StatsViewModel`
- Показывает статистику: общее количество денег и бонус.
- Подписан на изменения в `GameState`.

### `StockViewModel`
- Обёртка для `Stock`, реализующая логику покупки.
- Команда `PurchaseCommand` проверяет доступность и производит покупку.

### `StocksListViewModel`
- Управляет списком всех акций (обёрнутых в `StockViewModel`).

## 🖼️ View (Pages)

### `ClickerPage`
- Главная страница с кнопкой "Get Money" и текущими деньгами.
- Привязана к `ClickerViewModel`.

### `StatsPage`
- Показывает общую статистику.
- Использует `StatsViewModel`.

### `StocksPage`
- Список всех доступных акций с возможностью покупки.
- Использует `StocksListViewModel`.

## ⚙️ Dependency Injection

В `MauiProgram.cs`:
- `GameState` зарегистрирован как **Singleton**.
- Все ViewModel и Pages получают зависимости через DI.

```csharp
builder.Services.AddSingleton<GameState>();
builder.Services.AddSingleton<ClickerViewModel>();
builder.Services.AddSingleton<ClickerPage>();
// и т.д.
```

## ✅ Почему так?

- Единый `GameState` позволяет синхронизировать всё состояние.
- `INotifyPropertyChanged` обеспечивает реактивность UI.
- `ObservableCollection` обновляет UI при изменении списка акций.
- `ICommand` отделяет логику действий от представления.
- Разделение `Stock` и `StockViewModel` — чистая архитектура.

## 🚀 Скриншоты (опционально)

_Вы можете вставить скриншоты приложения здесь для визуализации интерфейса._

## 📄 Лицензия

Этот проект доступен под лицензией MIT. См. файл [LICENSE](./LICENSE) для подробностей.

## ✨ Авторы

- [Ваше имя или никнейм](https://github.com/yourusername)

---

**Enjoy clicking! 🚀**
