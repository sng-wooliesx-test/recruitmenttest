using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Settings;

namespace WooliesXChallenge.Client
{
    public class RecruitmentClient : IRecruitmentClient
    {
        private readonly RecruitmentClientSettings _settings;

        public RecruitmentClient(RecruitmentClientSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"{_settings.Uri}api/resource/products?token={_settings.Token}";
                var response = await httpClient.GetAsync(url);
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonResult);
            }
        }

        public async Task<IEnumerable<ShopperOrder>> GetShopperHistory()
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"{_settings.Uri}api/resource/shopperHistory?token={_settings.Token}";
                var response = await httpClient.GetAsync(url);
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ShopperOrder>>(jsonResult);
            }
        }
    }
}
