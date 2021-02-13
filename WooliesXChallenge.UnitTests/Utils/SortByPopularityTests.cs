using System.Collections.Generic;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Utils;
using Xunit;

namespace WooliesXChallenge.UnitTests.Utils
{
    public class SortByPopularityTests
    {
        [Fact]
        public void Test_SortByPopularity()
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

            var soldAmountLookup = calculator.CalculatePopularityBySoldAmount(orders);

            var products = new List<Product>
            {
                new Product {Name = "Product A"},
                new Product {Name = "Product B"},
                new Product {Name = "Product C"}
            };

            products.Sort(new SortByAmountSoldDescending(soldAmountLookup));

            Assert.Equal("Product C", products[0].Name);
            Assert.Equal("Product A", products[1].Name);
            Assert.Equal("Product B", products[2].Name);
        }
    }
}
