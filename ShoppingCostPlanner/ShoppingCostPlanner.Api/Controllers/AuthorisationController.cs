using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Application.Services;
using ShoppingCostPlanner.Domain.Models;

namespace ShoppingCostPlanner.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _usersService;

        public AuthorizationController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {
            var loginResult = _usersService.LoginUser(request);
            if (!loginResult.Success)
            {
                return BadRequest("Failed to login!");
            }

            return Ok(loginResult);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(TokenRefreshRequest request)
        {
            var refreshTokenResult = _usersService.Reauthorize(request);
            if (!refreshTokenResult.Success)
            {
                return BadRequest("Failed to refresh token!");
            }

            return Ok(refreshTokenResult);
        }
    }
}
