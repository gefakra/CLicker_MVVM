using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerMVVM.Service.Interface
{
    public interface IGameService
    {
        int GetMoney();
        void AddMoney(int amount);
        bool SpendMoney(int amount);
        int GetBonus();
        IReadOnlyList<IStock> GetStocks();
    }
}
