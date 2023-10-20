

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class TypePersonConfiguration :IEntityTypeConfiguration<TypePerson>
    {
        public void Configure(EntityTypeBuilder<TypePerson> builder){

            builder.ToTable("Type_Person");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            
        }

        
    }
