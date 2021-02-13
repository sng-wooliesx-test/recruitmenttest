using System;
using System.Threading.Tasks;
using WooliesXChallenge.Client;
using WooliesXChallenge.Settings;
using Xunit;

namespace WooliesXChallenge.IntegrationTests
{
    public class DebugServiceCalls
    {
        //[Fact]
        public async Task Call_GetShopperHistory()
        {
            var client = new RecruitmentClient(new RecruitmentClientSettings{
                Uri = "http://dev-wooliesx-recruitment.azurewebsites.net/",
                Token = "6439e813-ccff-4a43-884c-c71d2a4a6f33"
            });

            var result = await client.GetShopperHistory();
        }
    }
}
