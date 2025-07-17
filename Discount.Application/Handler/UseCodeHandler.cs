using Discount.Application.Interfaces;
using Discount.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handler
{
    public class UseCodeHandler : IUseCodeHandler
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public UseCodeHandler(IDiscountCodeRepository discountCodeRepository)
        {
            _discountCodeRepository = discountCodeRepository;
        }

        public byte Handle(string code)
        {
            return _discountCodeRepository.TryUse(code, out var result) ? result : (byte)0;
        }
    }
}
