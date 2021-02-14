using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesXChallenge.Services;

namespace WooliesXChallenge.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class SortController : ControllerBase
    {
        private readonly IProductService _productService;

        public SortController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Exercise 2 endpoint
        /// </summary>
        /// <param name="sortOption">Sort option must be either \"Low\", \"High\", \"Ascending\", \"Descending\", \"Recommended\" (case sensitive)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string sortOption)
        {
            (bool isValid, string error) result = SortValidator.Validate(sortOption);

            if (!result.isValid)
                return BadRequest(result.error);

            var sortedProducts = await _productService.GetSortedProducts(Enum.Parse<SortOrder>(sortOption));

            if (sortedProducts == null)
                return NotFound("No products found.");

            return Ok(sortedProducts);
        }
    }
}
