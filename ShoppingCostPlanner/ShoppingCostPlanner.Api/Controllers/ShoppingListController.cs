using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Application.Services;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Domain.Models;
using System.ComponentModel;

namespace ShoppingCostPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IUserService _userService;
        private readonly ILogger<ShoppingListController> _logger;

        public ShoppingListController(IShoppingListService shoppingListService, IUserService userService, ILogger<ShoppingListController> logger)
        {
            _shoppingListService = shoppingListService;
            _userService = userService;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("user/{userId}")]
        [Description("Get shopping list from a user (with the given id).")]
        public async Task<IActionResult> GetShoppingListByUserId(int userId)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByUserId(userId);
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();
            }

            return Ok(shoppingLists);
        }

        //[Authorize]
        [HttpPost("{shoppingListId}/item/{itemId}")]
        [Description("Adds to a list (list id) an item (item id).")]
        public async Task<IActionResult> AddItemToShoppingList(int shoppingListId, int itemId)
        {
            var shoppingList = await _shoppingListService.AddShoppingListItem(shoppingListId, itemId);
            if (shoppingList == null)
            {
                return NotFound();
            }
            shoppingList = _shoppingListService.UpdateTotal(shoppingList);


            return Ok(shoppingList);
        }

        [AllowAnonymous]
        [HttpGet("{Id}")]
        [Description("Get the shopping list (id).")]
        public async Task<IActionResult> GetShoppingListById(int Id)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByUserId(Id);
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();
            }

            return Ok(shoppingLists);
        }

        [HttpPost("create")]
        [Description("Adds a new shopping list to a user.")]
        public async Task<IActionResult> AddShoppingListToUser([FromBody] ShoppingListCreateModel shoppingList)
        {
            try
            {
                _shoppingListService.AddShoppingListToUser(shoppingList);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new shopping list!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }





    }
}
