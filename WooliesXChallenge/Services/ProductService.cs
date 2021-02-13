using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesXChallenge.Client;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Services
{
    public class ProductService : IProductService
    {
        private readonly IRecruitmentClient _client;
        private readonly ISortService _sortService;

        public ProductService(IRecruitmentClient client, ISortService sortService)
        {
            _client = client;
            _sortService = sortService;
        }

        public async Task<IEnumerable<Product>> GetSortedProducts(SortOrder sortOrder)
        {
            var products = await _client.GetProducts();

            if (sortOrder != SortOrder.Recommended)
                return _sortService.SortProducts(products.ToList(), sortOrder);

            var orders = await _client.GetShopperHistory();
            return _sortService.SortProducts(products.ToList(), sortOrder, orders.ToList());
        }
    }
}
