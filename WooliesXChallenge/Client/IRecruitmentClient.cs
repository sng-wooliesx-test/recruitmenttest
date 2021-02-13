using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;

namespace WooliesXChallenge.Client
{
    public interface IRecruitmentClient
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<ShopperOrder>> GetShopperHistory();

        Task<string> TrolleyCalculator(Trolley trolley);
    }
}