using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Entities
{
    public class ItemShoppingList
    {
        public int ItemId { get; set; }
        public int ShoppingListId { get; set; }
        public Item Item { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
