using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingCostPlannerDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public ShoppingListRepository(ShoppingCostPlannerDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingLists(int userId)
        {
            return await _dbContext.ShoppingLists
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task<ShoppingList> GetShoppingListById(int shoppingListId)
        {
            return await _dbContext.ShoppingLists
                .FirstOrDefaultAsync(s => s.Id == shoppingListId);
        }

        public async Task<Item> GetItemById(int itemId)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public void UpdateTotal(ShoppingList shoppingList)
        {
            shoppingList.UpdateTotal();
            SaveChangesAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingList>> GetShoppingListsById(int Id)
        {
            return await _dbContext.ShoppingLists
                .Where(s => s.Id == Id)
                .ToListAsync();
        }

        public void AddShoppingListToUser(ShoppingList shoppingList)
        {
            _dbContext.ShoppingLists.Add(shoppingList);
            var user = _userRepository.GetUserById2(shoppingList.UserId);
            user.ShoppingLists.Add(shoppingList);
            _dbContext.SaveChanges();

        }


    }
}
