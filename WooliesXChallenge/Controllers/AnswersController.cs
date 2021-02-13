using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesXChallenge.Dto;

namespace WooliesXChallenge.Controllers
{
    /// <summary>
    /// Entry point for api/answers
    /// </summary>
    [ApiController]
    [Route("api/answers")]
    public class AnswersController : ControllerBase
    {
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> Get()
        {
            return Ok(new UserResponse("Simon Ng"));
        }
    }
}
