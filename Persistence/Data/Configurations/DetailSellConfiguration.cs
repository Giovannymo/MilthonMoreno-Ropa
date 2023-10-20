

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class DetailSellConfiguration :IEntityTypeConfiguration<DetailSell>
    {
        public void Configure(EntityTypeBuilder<DetailSell> builder){

            builder.ToTable("Detail_Sell");

            builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ValueUnit)
            .IsRequired()
            .HasColumnType("int");
            
            builder.HasOne(p => p.Sell)
            .WithMany(p => p.DetailSells)
            .HasForeignKey(p => p.IdSellFk);

            builder.HasOne(p => p.Clothing)
            .WithMany(p => p.DetailSells)
            .HasForeignKey(p => p.IdProductFk);

            builder.HasOne(p => p.Size)
            .WithMany(p => p.DetailSells)
            .HasForeignKey(p => p.IdSizeFk);
        }

        
    }
