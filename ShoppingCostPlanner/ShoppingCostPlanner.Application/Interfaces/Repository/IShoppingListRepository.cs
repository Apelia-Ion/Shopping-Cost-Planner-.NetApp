using ShoppingCostPlanner.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Interfaces.Repository
{
    public interface IShoppingListRepository 
    {
        Task<IEnumerable<ShoppingList>> GetShoppingLists(int userId);
        Task<ShoppingList> GetShoppingListById(int shoppingListId);
        Task<Item> GetItemById(int itemId);
        void UpdateTotal(ShoppingList shoppingList);
        Task SaveChangesAsync();
        Task<IEnumerable<ShoppingList>> GetShoppingListsById(int Id);
    }
}
