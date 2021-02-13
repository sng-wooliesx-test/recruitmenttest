using System.Collections.Generic;
using System.Linq;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Utils
{
    public class ProductPopularityCalculator
    {
        public Dictionary<string, decimal> CalculatePopularityBySoldAmount(List<ShopperOrder> orders)
        {
            var orderDict = new Dictionary<string, decimal>();
            foreach (var product in orders.SelectMany(order => order.Products))
            {
                if (orderDict.ContainsKey(product.Name))
                {
                    orderDict[product.Name] += product.Quantity;
                }
                else
                {
                    orderDict[product.Name] = product.Quantity;
                }
            }

            return orderDict;
        }
    }
}
