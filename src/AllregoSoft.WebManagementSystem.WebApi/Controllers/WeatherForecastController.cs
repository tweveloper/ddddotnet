using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.WeatherForcasts.Queries.GetWeatherForecasts;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;

        public WeatherForecastController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var userId = _currentUserService.UserId;
            //var token = await HttpContext.GetTokenAsync("access_token");
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
