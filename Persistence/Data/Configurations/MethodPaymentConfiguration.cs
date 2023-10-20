using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class MethodPaymentConfiguration :IEntityTypeConfiguration<MethodPayment>
    {
        public void Configure(EntityTypeBuilder<MethodPayment> builder){

            builder.ToTable("Method_Payment");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(155);
            
        }

        
    }
