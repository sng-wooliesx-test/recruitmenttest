using System.Collections.Generic;
using System.Linq;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Services;
using Xunit;

namespace WooliesXChallenge.UnitTests.Services
{
    public class SortServiceTests
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Name = "Test Product A",
                Price = 99.99M,
                Quantity = 0.0M,
            },
            new Product
            {
                Name = "Test Product B",
                Price = 101.99M,
                Quantity = 1.0M,
            },
            new Product
            {
                Name = "Test Product C",
                Price = 10.99M,
                Quantity = 0.0M,
            },
            new Product
            {
                Name = "Test Product D",
                Price = 5.0M,
                Quantity = 0.0M,
            },
            new Product
            {
                Name = "Test Product F",
                Price = 999999999999.0M,
                Quantity = 0.0M,
            }
        };
        [Fact]
        public void SortService_Can_Sort_Low()
        {
            var sortService = new SortService();

            var sortResult = sortService.SortProducts(_products, SortOrder.Low).ToList();

            Assert.Equal(5, sortResult.Count);
            Assert.Equal(5.0M, sortResult[0].Price);
            Assert.Equal(10.99M, sortResult[1].Price);
            Assert.Equal(99.99M, sortResult[2].Price);
            Assert.Equal(101.99M, sortResult[3].Price);
            Assert.Equal(999999999999.0M, sortResult[4].Price);
        }

        [Fact]
        public void SortService_Can_Sort_High()
        {
            var sortService = new SortService();

            var sortResult = sortService.SortProducts(_products, SortOrder.High).ToList();

            Assert.Equal(5, sortResult.Count);
            Assert.Equal(999999999999.0M, sortResult[0].Price);
            Assert.Equal(101.99M, sortResult[1].Price);
            Assert.Equal(99.99M, sortResult[2].Price);
            Assert.Equal(10.99M, sortResult[3].Price);
            Assert.Equal(5.0M, sortResult[4].Price);




        }

        [Fact]
        public void SortService_Can_Sort_Ascending()
        {
            var sortService = new SortService();

            var sortResult = sortService.SortProducts(_products, SortOrder.Ascending).ToList();

            Assert.Equal(5, sortResult.Count);
            Assert.Equal("Test Product A", sortResult[0].Name);
            Assert.Equal("Test Product B", sortResult[1].Name);
            Assert.Equal("Test Product C", sortResult[2].Name);
            Assert.Equal("Test Product D", sortResult[3].Name);
            Assert.Equal("Test Product F", sortResult[4].Name);
        }

        [Fact]
        public void SortService_Can_Sort_Descending()
        {
            var sortService = new SortService();

            var sortResult = sortService.SortProducts(_products, SortOrder.Descending).ToList();

            Assert.Equal(5, sortResult.Count);
            Assert.Equal("Test Product F", sortResult[0].Name);
            Assert.Equal("Test Product D", sortResult[1].Name);
            Assert.Equal("Test Product C", sortResult[2].Name);
            Assert.Equal("Test Product B", sortResult[3].Name);
            Assert.Equal("Test Product A", sortResult[4].Name);
        }

        [Fact]
        public void SortService_Can_Sort_Recommended()
        {
            ShopperOrder[] orders = new[]
            {
                new ShopperOrder
                {
                    CustomerId = 123,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Test Product A",
                            Price = 99.99m,
                            Quantity = 3,
                        },
                        new Product
                        {
                            Name = "Test Product B",
                            Price = 101.99m,
                            Quantity = 1,
                        },
                        new Product
                        {
                            Name = "Test Product F",
                            Price = 999999999999m,
                            Quantity = 1,
                        }
                    }
                },
                new ShopperOrder
                {
                    CustomerId = 23,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Test Product A",
                            Price = 99.99m,
                            Quantity = 2,
                        },
                        new Product
                        {
                            Name = "Test Product B",
                            Price = 101.99m,
                            Quantity = 3,
                        },
                        new Product
                        {
                            Name = "Test Product F",
                            Price = 999999999999m,
                            Quantity = 1,
                        }
                    }
                },
                new ShopperOrder
                {
                    CustomerId = 23,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Test Product A",
                            Price = 99.99m,
                            Quantity = 1,
                        },
                        new Product
                        {
                            Name = "Test Product B",
                            Price = 101.99m,
                            Quantity = 1,
                        },
                        new Product
                        {
                            Name = "Test Product C",
                            Price = 10.99m,
                            Quantity = 1,
                        }
                    }
                }
            };

            var sortService = new SortService();

            var sortResult = sortService.SortProducts(_products, SortOrder.Recommended, orders.ToList()).ToList();

            Assert.Equal(5, sortResult.Count);
            Assert.Equal("Test Product A", sortResult[0].Name);
            Assert.Equal("Test Product B", sortResult[1].Name);
            Assert.Equal("Test Product F", sortResult[2].Name);
            Assert.Equal("Test Product C", sortResult[3].Name);
            Assert.Equal("Test Product D", sortResult[4].Name); // No orders on this one
        }
    }
}
