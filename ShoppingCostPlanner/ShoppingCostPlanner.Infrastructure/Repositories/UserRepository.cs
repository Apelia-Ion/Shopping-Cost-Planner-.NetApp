using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingCostPlannerDbContext _dbContext;

        public UserRepository(ShoppingCostPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.FromResult(_dbContext.Users.FirstOrDefault(u => u.Id == id));
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

        }

        public async Task  DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public User GetUserById2(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }



    }
}
