

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {

        builder.ToTable("Inventory");



        builder.Property(p => p.CodInventory)
        .IsRequired()
        .HasColumnType("int");
        builder.Property(p => p.ValueSellCop)
        .IsRequired()
        .HasColumnType("int");
        builder.Property(p => p.ValueSellUsd)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Clothing)
        .WithMany(p => p.Inventories)
        .HasForeignKey(p => p.IdClothingFk);


        builder.HasMany(i => i.Sizes)
        .WithMany(c => c.Inventories)
        .UsingEntity<InventorySize>(
            j => j
            .HasOne(pt => pt.Size) //La tabla
            .WithMany(t => t.InventorySizes) //Relaciona con la tabla
            .HasForeignKey(ut => ut.IdInventoryFk), //Donde existe un campo:

            j => j
            .HasOne(et => et.Inventory)
            .WithMany(et => et.InventorySizes)
            .HasForeignKey(e => e.IdSizeFk),
            j =>
            {
                j.ToTable("Inventory_Size");
                j.HasKey(t => new { t.IdInventoryFk, t.IdSizeFk });
            });




    }


}
