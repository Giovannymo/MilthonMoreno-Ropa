

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class SellConfiguration :IEntityTypeConfiguration<Sell>
    {
        public void Configure(EntityTypeBuilder<Sell> builder){

            builder.ToTable("Sell");

            builder.Property(p => p.Date)
            .IsRequired()
            .HasColumnType("DateTime");
            
            builder.HasOne(p => p.Employee)
            .WithMany(p => p.Sells)
            .HasForeignKey(p => p.IdEmployeeFk);

            builder.HasOne(p => p.Customer)
            .WithMany(p => p.Sells)
            .HasForeignKey(p => p.IdCustomerFk);

            builder.HasOne(p => p.MethodPayment)
            .WithMany(p => p.Sells)
            .HasForeignKey(p => p.IdMethodPaymentFk);


            
        }

        
    }
