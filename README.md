# 🖱️ ClickerMVVM

# ClickerMVVM — Clicker Game на .NET MAUI с архитектурой MVVM

---

## О проекте

**ClickerMVVM** — это простая, но функциональная кликер-игра, реализованная на .NET MAUI с использованием паттерна MVVM. В игре вы зарабатываете деньги кликами и покупаете акции, которые увеличивают ваш доход за клик.

Проект демонстрирует грамотное применение MVVM, Dependency Injection, команд и реактивного обновления UI.

---

## Основные возможности

- **Кликер на деньги** с возможностью увеличивать доход через бонусы.
- **Покупка акций (Stocks)**, которые увеличивают бонус за клик.
- Отдельные страницы для отображения счёта, статистики и списка акций.
- Использование **ObservableCollection** и **INotifyPropertyChanged** для автоматического обновления интерфейса.
- Чистая архитектура с разделением на Model, ViewModel, Service и View.
- Использование интерфейсов для легкой масштабируемости и тестирования.
- Навигация через **Shell** с табами.

---
## Технологии

- **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)** — кроссплатформенный UI-фреймворк
- C# 10 / .NET 7
- MVVM архитектура
- Dependency Injection через Microsoft.Extensions.DependencyInjection
- Команды (ICommand) для обработки UI-взаимодействий
- ObservableCollection и INotifyPropertyChanged для реактивного UI
- XAML для декларативного UI
  
## 🧩 Архитектура

Приложение построено по классической MVVM-архитектуре:
- **Model** — модели данных и бизнес-сущности (например, `GameState`, `Stock`). Они не зависят от UI и содержат свойства с уведомлением об изменениях.
- **ViewModel** — посредники между Model и View, реализуют логику и команды, связывают данные с UI. Например, `ClickerViewModel`, `StocksListViewModel`.
- **View** — визуальные компоненты XAML и их code-behind (`ClickerPage.xaml`, `StatsPage.xaml`), которые привязаны к ViewModel через BindingContext.

В дополнение:

- **Service** — слой сервисов с бизнес-логикой и интерфейсами (`IGameService`, `IStockService`), который инкапсулирует операции над моделями.
- **Dependency Injection** используется для внедрения зависимостей, что облегчает поддержку и тестирование.
- **Commands** (`ICommand`) используются для обработки событий UI, таких как нажатия кнопок.

## Структура проекта
```
/ClickerMVVM
│
├─ Model/ # Модели данных (GameState, Stock)
├─ Service/ # Логика игры и бизнес-правила (IGameService, StockService)
├─ ViewModel/ # ViewModel’и для связки UI и бизнес-логики
├─ Views/ # XAML страницы (ClickerPage, StatsPage, StocksPage)
├─ Resources/ # Ресурсы и стили
├─ Converters/ # Конвертеры для XAML (например, InverseBoolConverter)
└─ MauiProgram.cs # Настройка DI и запуск приложения
```

### 🧠 Model  
- **GameState** — состояние игры: деньги и акции.  
- **Stock** — акция: имя, стоимость, бонус, куплена ли.

---

### 🧠 ViewModel  
- **ClickerViewModel** — логика кнопки "Get Money".  
- **StatsViewModel** — отображение денег и бонуса.  
- **StockViewModel** — обёртка акции с покупкой.  
- **StocksListViewModel** — список акций.

---

### 🖼️ View (Pages)  
- **ClickerPage** — главный экран с кнопкой и деньгами.  
- **StatsPage** — статистика по деньгам и бонусам.  
- **StocksPage** — список акций с кнопками покупки.

---

### ⚙️ Dependency Injection  
 -`GameState`, сервисы, ViewModel и страницы — зарегистрированы как Singleton в `MauiProgram.cs`.


## ✅ Почему так?

- Чёткое разделение на Model, ViewModel и View упрощает поддержку и расширение кода.  
- Использование `INotifyPropertyChanged` обеспечивает автоматическое обновление UI при изменениях данных.  
- Dependency Injection через MAUI повышает тестируемость и гибкость приложения.  
- MVVM паттерн — стандарт для современных UI-приложений, поддерживает чистую архитектуру и масштабируемость.


## ✨ Авторы

- [Gefakra](https://github.com/gefakra)

---

**Enjoy clicking! 🚀**
