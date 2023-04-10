using Microsoft.AspNetCore.Authorization;
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





        [AllowAnonymous]
        [HttpGet("Get all users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            _logger.LogInformation("Get All Users performed");
            return Ok(users);
        }

        [Authorize]
        [HttpPost("Send-email")]
        public async Task<IActionResult> SendEmail(EmailSendModel email)
        {
            await _emailService.SendAsync(email);

            return Ok();
        }


        [AllowAnonymous]
        [HttpGet("Get user by/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting user by Id {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel user)
        {
            try
            {
                _userService.CreateUser(user);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating user");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpDelete("Delete user by/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting user with Id {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }





    }
}
