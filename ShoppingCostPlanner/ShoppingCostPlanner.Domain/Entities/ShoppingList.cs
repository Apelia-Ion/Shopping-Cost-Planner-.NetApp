using ShoppingCostPlanner.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Entities
{
    public class ShoppingList : BaseEntity
    {
        //public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        //many- to-many
        public virtual ICollection<ItemShoppingList> ItemShoppingLists { get; set; }
        public int Total { get; set; }
        //one to many 
        public virtual User User { get; set; }
    }
}
