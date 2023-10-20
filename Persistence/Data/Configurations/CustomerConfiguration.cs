

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class CustomerConfiguration :IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder){

            builder.ToTable("Customer");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            builder.Property(p => p.JoinDate)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.HasOne(p => p.TypePerson)
            .WithMany(p => p.Customers)
            .HasForeignKey(p => p.IdTypePersonFk);

            builder.HasOne(p => p.Municipality)
            .WithMany(p => p.Customers)
            .HasForeignKey(p => p.IdMunicipalityFk);

            
        }

        
    }
