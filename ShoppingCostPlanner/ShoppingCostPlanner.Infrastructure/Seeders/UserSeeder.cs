using Microsoft.EntityFrameworkCore;
using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Infrastructure.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Ion Apelia",
                    Username = "ionapelia",
                    Password = "password123",
                    Email = "ionapelia@gmail.com",
                    CreatedAt = DateTime.Now,
                    ShoppingLists = new List<ShoppingList>(),
                    RefreshToken = "123456"
                },
                new User
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Username = "janedoe",
                    Password = "password456",
                    Email = "janedoe@email.com",
                    CreatedAt = DateTime.Now,
                    ShoppingLists = new List<ShoppingList>(),
                    RefreshToken = "123456"
                }
            );
        }
    }

}
