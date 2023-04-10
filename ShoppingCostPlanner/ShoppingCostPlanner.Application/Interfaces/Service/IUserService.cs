using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        UserLoginResponse LoginUser(UserLoginRequest request);
        UserLoginResponse Reauthorize(TokenRefreshRequest tokenRefreshRequest);

    }
}
