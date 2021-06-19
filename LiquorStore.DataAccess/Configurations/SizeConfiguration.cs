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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasIndex(s => s.Name).IsUnique();
            builder.Property(s => s.Name).IsRequired();

            builder.HasMany(s => s.LiquorSizes)
                .WithOne(ls => ls.Size)
                .HasForeignKey(ls => ls.SizeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
