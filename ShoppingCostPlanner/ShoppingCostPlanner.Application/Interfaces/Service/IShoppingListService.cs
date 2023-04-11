using ShoppingCostPlanner.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Interfaces.Service
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingList>> GetShoppingListsByUserId(int userId);
        Task<ShoppingList> AddShoppingListItem(int shoppingListId, int itemId);
        Task<IEnumerable<ShoppingList>> GetShoppingListsById(int Id);
        ShoppingList UpdateTotal(ShoppingList shoppingList);
    }
}
