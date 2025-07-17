using Discount.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Factories
{
    public class DiscountCodeFactory : IDiscountCodeFactory
    {
        private readonly Random _random = new();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string Create(int length)
        {
            return new string(Enumerable.Range(0, length)
                .Select(_ => _chars[_random.Next(_chars.Length)]).ToArray());
        }
    }
}
