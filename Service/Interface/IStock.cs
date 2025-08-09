using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerMVVM.Service.Interface
{
    public interface IStock
    {
        string Name { get; }
        int Cost { get; }
        int Bonus { get; }
        bool IsPurchased { get; set; }
    }
}
