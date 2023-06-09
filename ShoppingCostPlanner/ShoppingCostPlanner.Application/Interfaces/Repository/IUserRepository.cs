﻿using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        void CreateUser(User user);
        Task DeleteUser(int id);
        User GetUserById2(int id);
    }
}
