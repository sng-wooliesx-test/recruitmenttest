using System.Collections.Generic;
using System.Linq;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Utils;
using Xunit;

namespace WooliesXChallenge.UnitTests.Utils
{
    public class ProductPopularityTests
    {
        [Fact]
        public void CalculatePopularityBySoldAmount_Test()
        {
            var orders = new List<ShopperOrder>
            {
                new ShopperOrder
                {
                    Products = new List<Product>
                    {
                        new Product {Name = "Product A", Quantity = 3},
                        new Product {Name = "Product B", Quantity = 4}
                    }
                },
                new ShopperOrder
                {
                    Products = new List<Product>
                    {
                        new Product {Name = "Product A", Quantity = 3},
                        new Product {Name = "Product C", Quantity = 10}
                    }
                }
            };

            var calculator = new ProductPopularityCalculator();

            var result = calculator.CalculatePopularityBySoldAmount(orders);

            Assert.Equal(6, result["Product A"]);
            Assert.Equal(4, result["Product B"]);
            Assert.Equal(10, result["Product C"]);
        }
    }
}
