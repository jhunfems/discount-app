using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Interfaces
{
    public interface IUseCodeHandler
    {
        byte Handle(string code);
    }
}
