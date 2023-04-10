using Microsoft.EntityFrameworkCore;
using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class ItemShoppingListSeeder
    {
        public static void SeedItemShoppingLists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemShoppingList>().HasData(
                new ItemShoppingList { ItemId = 1, ShoppingListId = 1 },
                new ItemShoppingList { ItemId = 2, ShoppingListId = 1 },
                new ItemShoppingList { ItemId = 3, ShoppingListId = 2 }
            );
        }
    }
}
