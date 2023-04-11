using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCostPlanner.Domain.Entities;
using ShoppingCostPlanner.Infrastructure.Seeders;
using Microsoft.Extensions.Options;

namespace ShoppingCostPlanner.Infrastructure.Context
{
    public class ShoppingCostPlannerDbContext : DbContext
    {
        public ShoppingCostPlannerDbContext(DbContextOptions<ShoppingCostPlannerDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creating the table relationships

            //one user has many shoppingLists
            modelBuilder.Entity<User>()
             .HasMany(u => u.ShoppingLists)
             .WithOne(sl => sl.User)
             .HasForeignKey(sl => sl.UserId);


            //many-to-many Item<->ShoppingList
            modelBuilder.Entity<ShoppingList>()
                .HasMany(sl => sl.ItemShoppingLists)
                .WithOne(isl => isl.ShoppingList)
                .HasForeignKey(isl => isl.ShoppingListId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.ItemShoppingLists)
                .WithOne(isl => isl.Item)
                .HasForeignKey(isl => isl.ItemId);

            modelBuilder.Entity<ItemShoppingList>()
                .HasKey(isl => new { isl.ItemId, isl.ShoppingListId });
            /*
            modelBuilder.Entity<ItemShoppingList>()
                .HasOne(isl => isl.Item)
                .WithMany(i => i.ItemShoppingLists)
                .HasForeignKey(isl => isl.ItemId);

            modelBuilder.Entity<ItemShoppingList>()
                .HasOne(isl => isl.ShoppingList)
                .WithMany(sl => sl.ItemShoppingLists)
                .HasForeignKey(isl => isl.ShoppingListId);
            */
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category);

            modelBuilder.Entity<Store>()
               .HasMany(c => c.Categories)
               .WithOne(i => i.Store);


            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);


            base.OnModelCreating(modelBuilder);
            //
            modelBuilder.SeedUsers();
             modelBuilder.SeedCategories();
             modelBuilder.SeedStores();
             modelBuilder.SeedItems();
             modelBuilder.SeedShoppingLists();
             modelBuilder.SeedItemShoppingLists();

        }
    }
}
