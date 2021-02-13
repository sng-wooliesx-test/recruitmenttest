using System.Collections.Generic;
using System.Linq;
using WooliesXChallenge.Dto;
using WooliesXChallenge.ExtensionMethods;

namespace WooliesXChallenge.Services
{
    public class SortService : ISortService
    {
        public IEnumerable<Product> SortProducts(List<Product> products, SortOrder sortOrder, List<ShopperOrder> orders = null) // TODO: refactor this
        {
            switch (sortOrder)
            {
                case SortOrder.Low:
                    return products.OrderBy(product => product.Price);
                case SortOrder.High:
                    return products.OrderByDescending(product => product.Price);
                case SortOrder.Ascending:
                    return products.OrderBy(product => product.Name);
                case SortOrder.Descending:
                    return products.OrderByDescending(product => product.Name);
                case SortOrder.Recommended:
                    return products.OrderByPopularity(orders);
            }

            return products;
        }
    }

    public enum SortOrder
    {
        Low,
        High,
        Ascending,
        Descending,
        Recommended
    }
}
