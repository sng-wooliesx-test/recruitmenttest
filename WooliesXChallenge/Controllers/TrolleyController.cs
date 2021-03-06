﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesXChallenge.Dto.Request;
using WooliesXChallenge.Services;

namespace WooliesXChallenge.Controllers
{
    [ApiController]
    [Route("api/trolleyTotal")]
    public class TrolleyController : ControllerBase
    {
        private readonly ITrolleyService _trolleyService;

        public TrolleyController(ITrolleyService trolleyService)
        {
            _trolleyService = trolleyService;
        }

        /// <summary>
        /// This is not the expert mode, my sandbox code for attempting the sandbox code is in the project WooliesXChallenge.Sandbox
        /// </summary>
        /// <param name="trolley"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetCheapestCartTotal([FromBody] Trolley trolley)
        {
            var context = new ValidationContext(trolley);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(trolley, context, results, true);

            if (!isValid)
            {
                return BadRequest(results.Select(validationResult => validationResult.ErrorMessage));
            }

            return Ok(await _trolleyService.GetCheapestCartTotal(trolley));
        }
    }
}
