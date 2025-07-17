using Discount.Domain.Entities;
using Discount.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly IDiscountCodeFactory _discountCodeFactory;
        private readonly ConcurrentDictionary<string, DiscountCode> _codes = new();
        private const string FilePath = "codes.json";

        public DiscountCodeRepository(IDiscountCodeFactory discountCodeFactory)
        {
            _discountCodeFactory = discountCodeFactory;
        }

        public async Task LoadAsync()
        {
            if (File.Exists(FilePath))
            {
                var json = await File.ReadAllTextAsync(FilePath);
                var data = JsonSerializer.Deserialize<Dictionary<string, DiscountCode>>(json);
                foreach (var kv in data!)
                    _codes.TryAdd(kv.Key, kv.Value);
            }
        }

        public async Task SaveAsync()
        {
            var json = JsonSerializer.Serialize(_codes, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePath, json);
        }

        public IEnumerable<string> Generate(int count, byte length)
        {
            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string code;
                do
                {
                    code = _discountCodeFactory.Create(length);
                } while (!_codes.TryAdd(code, new DiscountCode { Code = code, IsUsed = false }));
                list.Add(code);
            }

            _ = SaveAsync(); // Fire and forget
            return list;
        }

        public bool TryUse(string code, out byte result)
        {
            if (_codes.TryGetValue(code, out var discount))
            {
                lock (discount)
                {
                    if (discount.IsUsed)
                    {
                        result = 2; // already used
                        return true;
                    }

                    discount.IsUsed = true;
                    _ = SaveAsync();
                    result = 1; // success
                    return true;
                }
            }

            result = 0; // not found
            return false;
        }
    }
}
