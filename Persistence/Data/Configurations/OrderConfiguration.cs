

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class OrderConfiguration :IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder){

            builder.ToTable("Order");

            builder.Property(p => p.Date)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.HasOne(p => p.Employee)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.IdEmployeeFk);

            builder.HasOne(p => p.Customer)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.IdCustomerFk);

            builder.HasOne(p => p.Status)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.IdStatusFk);
            
        }

        
    }
