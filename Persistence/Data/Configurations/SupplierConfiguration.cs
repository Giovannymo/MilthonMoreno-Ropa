

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class SupplierConfiguration :IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder){

            builder.ToTable("Supplier");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            builder.Property(p => p.NitSupplier)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(p => p.TypePerson)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(p => p.IdTypePersonFk);

            builder.HasOne(p => p.Municipality)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(p => p.IdMunicipalityFk);

            
        }

        
    }
