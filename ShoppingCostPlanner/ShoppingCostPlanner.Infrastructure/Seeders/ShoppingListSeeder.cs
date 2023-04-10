using Microsoft.EntityFrameworkCore;
using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class ShoppingListSeeder
    {
        public static void SeedShoppingLists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingList>().HasData(
                new ShoppingList { Id = 1, UserId = 1, Name = "Groceries", Total = 0 },
                new ShoppingList { Id = 2, UserId = 2, Name = "Farmers Market", Total = 0 }
            );
        }
    }
}
