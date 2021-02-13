using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WooliesXChallenge.Controllers;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;
using WooliesXChallenge.Services;
using Xunit;

namespace WooliesXChallenge.UnitTests.Controller
{

    public class TrolleyControllerTests
    {
        private TrolleyController _controller;
        private Mock<ITrolleyService> _trolleyServiceMock = new Mock<ITrolleyService>();

        [Fact]
        public async Task Test_GetCheapestCartTotal_NullProps_ShouldReturnBadRequest()
        {
            _trolleyServiceMock.Setup(x => x.GetCheapestCartTotal(It.IsAny<Trolley>())).ReturnsAsync("");

            _controller = new TrolleyController(_trolleyServiceMock.Object);

            var response = await _controller.GetCheapestCartTotal(new Trolley()) as ObjectResult;

            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async Task Test_GetCheapestCartTotal_Props_ShouldReturn200()
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

            _trolleyServiceMock.Setup(x => x.GetCheapestCartTotal(It.IsAny<Trolley>())).ReturnsAsync("");

            _controller = new TrolleyController(_trolleyServiceMock.Object);

            var response = await _controller.GetCheapestCartTotal(trolley) as ObjectResult;

            Assert.Equal(200, response.StatusCode);
        }
    }
}
