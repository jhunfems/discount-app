using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Interfaces
{
    public interface IDiscountCodeFactory
    {
        string Create(int length);
    }
}
