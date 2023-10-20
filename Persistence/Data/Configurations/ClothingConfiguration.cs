
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ClothingConfiguration : IEntityTypeConfiguration<Clothing>

    { 
        public void Configure(EntityTypeBuilder<Clothing> builder)
    {
        builder.ToTable("Clothing");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.ValueUnitCop)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.ValueUnitUsd)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(p => p.State)
        .WithMany(p => p.Clothings)
        .HasForeignKey(p => p.IdStateFk);

        builder.HasOne(p => p.TypeProtection)
        .WithMany(p => p.Clothings)
        .HasForeignKey(p => p.IdTypeProtectionFk);

        builder.HasOne(p => p.Genre)
        .WithMany(p => p.Clothings)
        .HasForeignKey(p => p.IdGenreFk);

    
    }
        
    }
}