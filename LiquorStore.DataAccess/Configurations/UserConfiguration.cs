using LiquorStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Username)
                .HasMaxLength(25)
                .IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.CustormerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
