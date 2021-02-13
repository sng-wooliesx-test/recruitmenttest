using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetSortedProducts(SortOrder sortOrder);
    }
}