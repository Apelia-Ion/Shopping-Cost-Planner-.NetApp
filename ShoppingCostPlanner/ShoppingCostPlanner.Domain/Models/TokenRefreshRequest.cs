using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Models
{
    public class TokenRefreshRequest
    {
        public string ExpiredToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
