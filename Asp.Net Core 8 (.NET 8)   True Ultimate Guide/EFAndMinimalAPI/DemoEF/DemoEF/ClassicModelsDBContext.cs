using DemoEF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DemoNop.Data
{
    public class ClassicModelsDBContext : DbContext
    {
        public ClassicModelsDBContext()
        {
        }

        public ClassicModelsDBContext(DbContextOptions<ClassicModelsDBContext> options)
       : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLines> ProductLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations
            modelBuilder.Entity<ProductLines>(
            dob =>
            {
                dob.ToTable("productLines");
                dob.HasKey(b => b.ProductLine);
            });

            modelBuilder.Entity<Product>(
            ob =>
            {
                ob.ToTable("products");
                ob.HasKey(o => o.ProductCode);

                ob.HasOne<ProductLines>(s => s.ProductLines).WithMany(g => g.Products).HasForeignKey(s => s.ProductLine);
            });

            modelBuilder.Entity<Product>()
           .Property(b => b.ProductCode)
           .IsRequired();

            modelBuilder.Entity<ProductLines>()
           .Property(b => b.ProductLine)
           .IsRequired();
        }
    }
}
