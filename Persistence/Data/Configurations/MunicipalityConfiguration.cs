

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class MunicipalityConfiguration :IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> builder){

            builder.ToTable("Municipality");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            builder.HasOne(p => p.State)
            .WithMany(p => p.Municipalities)
            .HasForeignKey(p => p.IdStateFk);

        }

        
    }
