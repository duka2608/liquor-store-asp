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
    public class LiquorConfiguration : IEntityTypeConfiguration<Liquor>
    {
        public void Configure(EntityTypeBuilder<Liquor> builder)
        {
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Price).IsRequired();
            builder.Property(l => l.Description).IsRequired(false);

            builder.HasMany(l => l.LiquorSizes)
                .WithOne(ls => ls.Liquor)
                .HasForeignKey(ls => ls.LiquorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
