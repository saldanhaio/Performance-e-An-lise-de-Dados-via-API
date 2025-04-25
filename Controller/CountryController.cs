using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using CodeconChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeconChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly UserService _userService;

        public CountryController(UserService userService)
        {
            _userService = userService;
        }

        // GET /top-countries
        [HttpGet("top-countries")]
        public async Task<IActionResult> GetTopCountries()
        {
            var (result, time) = await ExecutionTimer.MeasureAsync(() => Task.FromResult(_userService.GetTopCountries()));
            return Ok(new ReturnData<List<KeyValuePair<string, int>>>
            {
                Data = result,
                ProcessingTimeMs = time,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
