using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingListsByUserId(int userId)
        {
            return await _shoppingListRepository.GetShoppingLists(userId);
        }
        public async Task<ShoppingList> AddShoppingListItem(int shoppingListId, int itemId)
        {
            var shoppingList = await _shoppingListRepository.GetShoppingListById(shoppingListId);
            if (shoppingList == null)
            {
                return null;
            }

            var item = await _shoppingListRepository.GetItemById(itemId);
            if (item == null)
            {
                return null;
            }

            var itemShoppingList = new ItemShoppingList { Item = item, ShoppingList = shoppingList };

            if (shoppingList.ItemShoppingLists == null)
            {
                shoppingList.ItemShoppingLists = new List<ItemShoppingList>();
            }

            shoppingList.ItemShoppingLists.Add(itemShoppingList);

            await _shoppingListRepository.SaveChangesAsync();

            return shoppingList;
        }


    }

}
