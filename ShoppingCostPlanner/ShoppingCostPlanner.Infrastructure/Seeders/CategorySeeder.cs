using Microsoft.EntityFrameworkCore;
using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class CategorySeeder
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Grocery",
                    StoreId = 1,
                    Items = new List<Item>(),
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    StoreId= 1,
                    Items = new List<Item>()
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
