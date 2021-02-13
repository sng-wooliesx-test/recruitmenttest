using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesXChallenge.Client;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;
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

        [Fact]
        public async Task Call_TrolleyCalculator()
        {
            var trolley = new Trolley
            {
                Products = new List<Product>
                {
                    new Product {Name = "Test Product A", Price = 10}
                },
                Specials = new List<Special>
                {
                    new Special { Quantities = new List<Quantity>
                        {
                            new Quantity { Name = "Test Product A", quantity = 5}
                        },
                        Total = 5
                    },
                    new Special { Quantities = new List<Quantity>
                        {
                            new Quantity { Name = "Test Product A", quantity = 3}
                        },
                        Total = 3
                    },
                },
                Quantities = new List<Quantity>
                {
                    new Quantity {Name = "Test Product A", quantity = 11}
                }
            };

            var client = new RecruitmentClient(new RecruitmentClientSettings
            {
                Uri = "http://dev-wooliesx-recruitment.azurewebsites.net/",
                Token = "6439e813-ccff-4a43-884c-c71d2a4a6f33"
            });

            var result = await client.TrolleyCalculator(trolley);

            Assert.Equal("11.0", result);
        }
    }
}
