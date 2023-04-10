using ShoppingCostPlanner.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Entities
{
    public class Store : BaseEntity
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
    }
}
