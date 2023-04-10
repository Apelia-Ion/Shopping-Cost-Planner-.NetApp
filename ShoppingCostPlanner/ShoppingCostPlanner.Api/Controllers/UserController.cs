using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Domain.Models;

namespace ShoppingCostPlanner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, ILogger<UserController> logger, IEmailService emailService)
        {
            _userService = userService;
            _logger = logger;
            _emailService = emailService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            _logger.LogInformation("Get All Users performed");
            return Ok(users);
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(EmailSendModel email)
        {
            await _emailService.SendAsync(email);

            return Ok();
        }





    }
}
