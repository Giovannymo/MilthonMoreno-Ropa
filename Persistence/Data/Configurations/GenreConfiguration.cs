

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class GenreConfiguration :IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder){

            builder.ToTable("Genre");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(255);
            
            
        }

        
    }
