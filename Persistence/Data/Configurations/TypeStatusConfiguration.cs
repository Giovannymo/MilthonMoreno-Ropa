

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class TypeStatusConfiguration :IEntityTypeConfiguration<TypeStatus>
    {
        public void Configure(EntityTypeBuilder<TypeStatus> builder){

            builder.ToTable("Type_Status");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(155);
            
        }

        
    }
