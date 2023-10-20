

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class DetailOrderConfiguration :IEntityTypeConfiguration<DetailOrder>
    {
        public void Configure(EntityTypeBuilder<DetailOrder> builder){

            builder.ToTable("Detail_Order");

            builder.Property(p => p.AmountProduce)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.AmountProduced)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(p => p.Order)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.IdOrderFk);

            builder.HasOne(p => p.Clothing)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.IdClothingFk);

            builder.HasOne(p => p.Color)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.IdColorFk);

            builder.HasOne(p => p.Status)
            .WithMany(p => p.DetailOrders)
            .HasForeignKey(p => p.IdStatusFk);
            
            
        }

        
    }
