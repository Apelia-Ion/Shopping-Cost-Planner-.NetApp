using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Domain.Models
{
    public class ShoppingListCreateModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
