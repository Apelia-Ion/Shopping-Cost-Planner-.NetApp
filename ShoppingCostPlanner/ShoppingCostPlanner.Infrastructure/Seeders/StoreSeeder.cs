using Microsoft.EntityFrameworkCore;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class StoreSeeder
    {
        public static void SeedStores(this ModelBuilder modelBuilder)
        {
            var stores = new List<Store>
            {
                new Store
                {
                    Id = 1,
                    Name = "Walmart",
                    Items = new List<Item>()
                },
                new Store
                {
                    Id = 2,
                    Name = "Target",
                    Items = new List<Item>()
                }
            };

            modelBuilder.Entity<Store>().HasData(stores);
        }
    }
}
