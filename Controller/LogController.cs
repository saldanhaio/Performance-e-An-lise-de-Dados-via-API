using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using CodeconChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeconChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly UserService _userService;

        public LogController(UserService userService)
        {
            _userService = userService;
        }

        // GET /active-users-per-day
        [HttpGet("active-users-per-day")]
        public async Task<IActionResult> GetActiveUsersPerDay([FromQuery] int? min)
        {
            var (result, time) = await ExecutionTimer.MeasureAsync(() => Task.FromResult(_userService.GetActiveUsersPerDay(min)));
            return Ok(new ReturnData<Dictionary<DateTime, int>>
            {
                Data = result,
                ProcessingTimeMs = time,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
