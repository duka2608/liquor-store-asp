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
    class LiquorTypeConfiguration : IEntityTypeConfiguration<LiquorType>
    {
        public void Configure(EntityTypeBuilder<LiquorType> builder)
        {
            builder.HasIndex(lt => lt.Name).IsUnique();
            builder.Property(lt => lt.Name).IsRequired();
        }
    }
}
