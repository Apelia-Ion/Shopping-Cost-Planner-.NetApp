using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCostPlanner.Application.Interfaces.Service;

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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetShoppingListByUserId(int userId)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByUserId(userId);
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();
            }

            return Ok(shoppingLists);
        }

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

    }
}
