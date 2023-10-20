

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class StatusConfiguration :IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder){

            builder.ToTable("Status");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(255);

            builder.HasOne(p => p.TypeStatus)
            .WithMany(p => p.Status)
            .HasForeignKey(p => p.IdTypeStatusFk);
            
        }

        
    }
