using Microsoft.EntityFrameworkCore;
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
    }
}
