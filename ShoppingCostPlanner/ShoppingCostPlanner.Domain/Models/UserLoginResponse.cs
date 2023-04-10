using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Models
{
    public class UserLoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public UserLoginResponse()
        {
        }

        public UserLoginResponse(string token, string refreshToken)
        {
            Success = true;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
