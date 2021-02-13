using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Utils;

namespace WooliesXChallenge.ExtensionMethods
{
    public static class ProductExtensions
    {
        public static List<Product> OrderByPopularity(this List<Product> products, List<ShopperOrder> orders)
        {
            var calculator = new ProductPopularityCalculator();

            var soldAmountLookup = calculator.CalculatePopularityBySoldAmount(orders);

            products.Sort(new SortByAmountSoldDescending(soldAmountLookup));

            return products;
        }
    }
}
