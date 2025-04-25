using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using CodeconChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeconChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly UserService _userService;

        public TeamController(UserService userService)
        {
            _userService = userService;
        }

        // GET /team-insights
        [HttpGet("team-insights")]
        public async Task<IActionResult> GetTeamInsights()
        {
            var (result, time) = await ExecutionTimer.MeasureAsync(() => Task.FromResult(_userService.GetTeamInsights()));
            return Ok(new ReturnData<object>
            {
                Data = result,
                ProcessingTimeMs = time,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
