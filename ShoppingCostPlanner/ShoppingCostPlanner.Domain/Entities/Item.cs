using ShoppingCostPlanner.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Entities
{
    public class Item : BaseEntity

    {
      
        //public int Id { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<ItemShoppingList> ItemShoppingLists { get; set; }

        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}
