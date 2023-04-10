using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class ItemSeeder
    {
        public static void SeedItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, StoreId = 1, CategoryId = 1, Name = "Milk", Quantity = 1, Price = 2.99M, Description = "Whole Milk", IsCompleted = false },
                new Item { Id = 2, StoreId = 2, CategoryId = 1, Name = "Bread", Quantity = 2, Price = 1.99M, Description = "Wheat Bread", IsCompleted = false },
                new Item { Id = 3, StoreId = 1, CategoryId = 1, Name = "Eggs", Quantity = 1, Price = 1.99M, Description = "Organic Large Eggs", IsCompleted = false }
            );
        }
    }
}
