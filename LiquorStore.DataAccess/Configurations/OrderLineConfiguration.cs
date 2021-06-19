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
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(ol => ol.LiquorName).IsRequired();
            builder.Property(ol => ol.Price).IsRequired();
            builder.Property(ol => ol.Quantity).IsRequired();

            builder.HasOne(ol => ol.Liquor)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.LiquorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
