using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Entities
{
    public class DiscountCode
    {
        public string Code { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
    }
}
