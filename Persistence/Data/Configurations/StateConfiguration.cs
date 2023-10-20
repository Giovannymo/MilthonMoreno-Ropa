

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class StateConfiguration :IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder){

            builder.ToTable("State");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            builder.HasOne(p => p.Country)
            .WithMany(p => p.States)
            .HasForeignKey(p => p.IdCountryFk);
            
        }

        
    }
