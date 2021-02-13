using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesXChallenge.Dto.Request;

namespace WooliesXChallenge.Controllers
{
    [ApiController]
    [Route("api/trolleyTotal")]
    public class TrolleyController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetCheapestCartTotal([FromBody] Trolley trolley)
        {
            return Ok();
        }
    }
}
