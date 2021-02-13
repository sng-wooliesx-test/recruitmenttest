using System.Threading.Tasks;
using WooliesXChallenge.Dto.Request;

namespace WooliesXChallenge.Services
{
    public interface ITrolleyService
    {
        Task<string> GetCheapestCartTotal(Trolley trolley);
    }
}