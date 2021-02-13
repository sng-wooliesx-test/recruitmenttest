using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Client
{
    public interface IRecruitmentClient
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<ShopperOrder>> GetShopperHistory();
    }
}