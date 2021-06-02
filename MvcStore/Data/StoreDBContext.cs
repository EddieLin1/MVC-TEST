using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MvcStore.Models;

#nullable disable

namespace MvcStore.Data
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }
        public DbSet<Item> ItemsRepo { get; set; }
        public DbSet<CartItem> ShoppingCartItems {get; set;}
        public DbSet<Cart> Cart {get; set;}
        public DbSet<Order> OrderList {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:StoreDBContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Item>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Item>().HasData(
                new Item {Id = 1, Name = "Bananas (Bunch)", Description = "Yellow/Green bananas, high in potassium", Price = 1.95, QuantitySold = 0},
                new Item {Id = 2, Name = "English Cucumbers", Description = "Long and green and high in minerals good for skin", Price = 2.48, QuantitySold = 0},
                new Item {Id = 3, Name = "Strawberries", Description = "Sweet and red strawberries, very juicy", Price = 4.98, QuantitySold = 0},
                new Item {Id = 4, Name = "Green Onion", Description = "Long green stalks, also called \"Scallions\"", Price = 0.98, QuantitySold = 0},
                new Item {Id = 5, Name = "Eggs", Description = "Grade A large omega 3 eggs", Price = 3.98, QuantitySold = 0},
                new Item {Id = 6, Name = "Avocados (Bag)", Description = "Green Avocados from Mexico", Price = 4.59, QuantitySold = 0}
            );
                
            modelBuilder.Entity<CartItem>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Cart>()
                .HasKey(p => p.CartId);

            modelBuilder.Entity<Order>()
                .HasKey(p => p.OrderId);
                

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}