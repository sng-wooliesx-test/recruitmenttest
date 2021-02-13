using System.Collections.Generic;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Services
{
    public interface ISortService
    {
        IEnumerable<Product> SortProducts(List<Product> products, SortOrder sortOrder, List<ShopperOrder> orders = null);
    }
}