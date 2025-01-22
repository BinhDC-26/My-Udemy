using DemoNop.Core.Domain.Entities;
using DemoNop.Data.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DemoNop.Data
{
    public class NorthwindDBContext : DbContext
    {
        public NorthwindDBContext()
        {
        }

        public NorthwindDBContext(DbContextOptions<NorthwindDBContext> options)
       : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations
            new CustomerBuilder().Configure(modelBuilder.Entity<Customer>());
            new ProductBuilder().Configure(modelBuilder.Entity<Product>());
            new UserInfoBuilder().Configure(modelBuilder.Entity<UserInfo>());
        }
    }
}
