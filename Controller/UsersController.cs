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
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // POST /users
        [HttpPost]
        public IActionResult AddUsers([FromBody] List<User> users)
        {
            if (users == null || !users.Any())
                return BadRequest("No users provided.");

            _userService.AddUsers(users);
            return Ok(new { message = "Users added successfully" });
        }

        // GET /superusers
        [HttpGet("superusers")]
        public async Task<IActionResult> GetSuperUsers()
        {
            var (result, time) = await ExecutionTimer.MeasureAsync(() => Task.FromResult(_userService.GetSuperUsers()));
            return Ok(new ReturnData<List<User>>
            {
                Data = result,
                ProcessingTimeMs = time,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
