using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCostPlanner.Application.Interfaces.Service;
using System.ComponentModel;

namespace ShoppingCostPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [AllowAnonymous]
        [Description("Get shopping list from a user (with the given id).")]
        [HttpGet("/{userId}")]
        public async Task<IActionResult> GetShoppingListByUserId(int userId)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByUserId(userId);
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();
            }

            return Ok(shoppingLists);
        }

        [Authorize]
        [Description("Adds to a list (list id) an item (item id).")]
        [HttpPost("{shoppingListId}/item/{itemId}")]
        public async Task<IActionResult> AddItemToShoppingList(int shoppingListId, int itemId)
        {
            var shoppingList = await _shoppingListService.AddShoppingListItem(shoppingListId, itemId);
            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        [AllowAnonymous]
        [Description("Get the shopping list (id).")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetShoppingListById(int Id)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByUserId(Id);
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();
            }

            return Ok(shoppingLists);
        }

    }
}
