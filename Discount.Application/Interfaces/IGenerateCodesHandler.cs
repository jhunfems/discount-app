using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Interfaces
{
    public interface IGenerateCodesHandler
    {
        IEnumerable<string> Handle(int count, byte length);
    }
}
