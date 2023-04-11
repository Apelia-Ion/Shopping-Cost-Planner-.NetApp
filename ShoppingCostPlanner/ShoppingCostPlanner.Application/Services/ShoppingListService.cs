using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IUserRepository userRepository)
        {
            _shoppingListRepository = shoppingListRepository;
            _userRepository = userRepository;
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

        public ShoppingList UpdateTotal(ShoppingList shoppingList)
        {
            _shoppingListRepository.UpdateTotal(shoppingList);

            return shoppingList;
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingListsById(int Id)
        {
            return await _shoppingListRepository.GetShoppingListsById(Id);
        }

        public void AddShoppingListToUser (ShoppingListCreateModel shoppingList)
        {

            var newShoppingList= new ShoppingList
            {
                UserId = shoppingList.UserId,
                Name = shoppingList.Name
                
            };

            _shoppingListRepository.AddShoppingListToUser(newShoppingList);

        }


    }

}
