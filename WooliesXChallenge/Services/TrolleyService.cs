using System.Threading.Tasks;
using WooliesXChallenge.Client;
using WooliesXChallenge.Dto.Request;

namespace WooliesXChallenge.Services
{
    public class TrolleyService : ITrolleyService
    {
        private readonly IRecruitmentClient _client;

        public TrolleyService(IRecruitmentClient client)
        {
            _client = client;
        }

        public async Task<string> GetCheapestCartTotal(Trolley trolley)
        {
            return await _client.TrolleyCalculator(trolley);
        }
    }
}
