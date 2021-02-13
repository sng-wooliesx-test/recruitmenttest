using System.Collections.Generic;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Utils
{
    public class SortByAmountSoldDescending : IComparer<Product>
    {
        private readonly Dictionary<string, decimal> _popular;

        public SortByAmountSoldDescending(Dictionary<string, decimal> popular)
        {
            _popular = popular;
        }

        public int Compare(Product product1, Product product2)
        {
            if (!_popular.ContainsKey(product1.Name))
                return 1;

            if (!_popular.ContainsKey(product2.Name))
                return -1;

            if (_popular[product1.Name] == _popular[product2.Name]) return 0;
            
            if (_popular[product1.Name] < _popular[product2.Name]) return 1;
            
            return -1;
        }
    }
}