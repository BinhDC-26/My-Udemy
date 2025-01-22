using DemoNop.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoNop.Data.Builders
{
    public class CategoryBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories")
                .Property(s => s.Id)
               .HasColumnName("CategoryID")
               .HasDefaultValue(0)
               .IsRequired();
        }
    }
}
