

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class ColorConfiguration :IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder){

            builder.ToTable("Color");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(255);

            
        }

        
    }
