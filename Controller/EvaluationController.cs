using CodeconChallenge.Helpers;
using CodeconChallenge.Models;
using CodeconChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly UserService _userService;

        public EvaluationController(UserService userService)
        {
            _userService = userService;
        }

        // GET /evaluation
        [HttpGet("evaluation")]
        public async Task<IActionResult> Evaluation()
        {
            var evaluationResults = new List<object>();

            // Teste para superusers
            var (superUsersResult, superUsersTime) = await ExecutionTimer.MeasureAsync<List<SuperUser>>(() => Task.FromResult(_userService.GetSuperUsers()));
            evaluationResults.Add(new
            {
                Endpoint = "/superusers",
                Status = 200,
                Time = superUsersTime,
                IsValidJson = superUsersResult != null
            });

            // Teste para top-countries
            var (topCountriesResult, topCountriesTime) = await ExecutionTimer.MeasureAsync<List<Country>>(() => Task.FromResult(_userService.GetTopCountries()));
            evaluationResults.Add(new
            {
                Endpoint = "/top-countries",
                Status = 200,
                Time = topCountriesTime,
                IsValidJson = topCountriesResult != null
            });

            // Teste para team-insights
            var (teamInsightsResult, teamInsightsTime) = await ExecutionTimer.MeasureAsync<List<TeamInsight>>(() => Task.FromResult(_userService.GetTeamInsights()));
            evaluationResults.Add(new
            {
                Endpoint = "/team-insights",
                Status = 200,
                Time = teamInsightsTime,
                IsValidJson = teamInsightsResult != null
            });

            // Teste para active-users-per-day
            var (activeUsersResult, activeUsersTime) = await ExecutionTimer.MeasureAsync<List<ActiveUser>>(() => Task.FromResult(_userService.GetActiveUsersPerDay()));
            evaluationResults.Add(new
            {
                Endpoint = "/active-users-per-day",
                Status = 200,
                Time = activeUsersTime,
                IsValidJson = activeUsersResult != null
            });

            return Ok(new
            {
                EvaluationResults = evaluationResults,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
