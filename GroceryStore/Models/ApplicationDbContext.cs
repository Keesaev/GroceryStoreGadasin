using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User adminUser = new User { Id = 1, Login = "Admin", Password = "Admin", Role = "admin" };

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<User>().ToTable("User");
            base.OnModelCreating(modelBuilder);
        }
    }
}
