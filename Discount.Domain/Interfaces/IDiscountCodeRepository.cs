using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Interfaces
{
    public interface IDiscountCodeRepository
    {
        Task LoadAsync();
        Task SaveAsync();
        IEnumerable<string> Generate(int count, byte length);
        bool TryUse(string code, out byte result);
    }
}
