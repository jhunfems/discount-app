using Discount.Application.Interfaces;
using Discount.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handler
{
    public class GenerateCodesHandler : IGenerateCodesHandler
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public GenerateCodesHandler(IDiscountCodeRepository discountCodeRepository)
        {
            _discountCodeRepository = discountCodeRepository;
        }

        public IEnumerable<string> Handle(int count, byte length)
        {
            return _discountCodeRepository.Generate(count, length);
        }
    }
}
