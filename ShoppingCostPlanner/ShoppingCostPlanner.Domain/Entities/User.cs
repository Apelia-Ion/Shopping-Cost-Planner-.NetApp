using ShoppingCostPlanner.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Entities
{
    public class User : BaseEntity
    {

        public User()
        {
            ShoppingLists = new List<ShoppingList>();
        }
        // public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ShoppingList>? ShoppingLists { get; set; }
        public string RefreshToken { get; set; }
    }
}
