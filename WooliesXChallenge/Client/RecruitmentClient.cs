using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;
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

        public async Task<string> TrolleyCalculator(Trolley trolley)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"{_settings.Uri}api/resource/trolleyCalculator?token={_settings.Token}";
                var response = await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(trolley), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
