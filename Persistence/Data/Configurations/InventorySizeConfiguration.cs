

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class InventorySizeConfiguration :IEntityTypeConfiguration<InventorySize>
    {
        public void Configure(EntityTypeBuilder<InventorySize> builder){

            builder.ToTable("Inventory_Size");

            builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("int");
            
            

            
        }

        
    }
