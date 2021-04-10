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
        public DbSet<CartItem> ShoppingCart {get; set;}

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
                
            modelBuilder.Entity<CartItem>()
                .HasKey(p => p.Id);
                

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}