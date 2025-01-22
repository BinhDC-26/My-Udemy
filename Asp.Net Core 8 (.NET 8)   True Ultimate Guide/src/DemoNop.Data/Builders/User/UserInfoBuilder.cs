using DemoNop.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Data.Builders
{
    public class UserInfoBuilder : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("userinfo")
                .Property(s => s.Id)
                .HasColumnName("UserID")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}
