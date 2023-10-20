

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class TypeProtectionConfiguration :IEntityTypeConfiguration<TypeProtection>
    {
        public void Configure(EntityTypeBuilder<TypeProtection> builder){

            builder.ToTable("TypeProtection");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(155);
            
        }

        
    }
