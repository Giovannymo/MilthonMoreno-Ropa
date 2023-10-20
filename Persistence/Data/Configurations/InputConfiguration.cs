

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class InputConfiguration :IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder){

            builder.ToTable("Input");

            builder.Property(p => p.ValueUnit)
            .IsRequired()
            .HasColumnType("int");
            builder.Property(p => p.StockMin)
            .IsRequired()
            .HasColumnType("int");
            builder.Property(p => p.StockMax)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(155);

            builder.HasMany(i =>i.Clothings) 
            .WithMany(c => c.Inputs)
            .UsingEntity<InputClothing>(
                j => j 
                .HasOne(pt => pt.Clothing) //La tabla
                .WithMany(t => t.InputClothings) //Relaciona con la tabla
                .HasForeignKey(ut => ut.IdInputFk), //Donde existe un campo:

                j => j
                .HasOne(et => et.Input)
                .WithMany(et => et.InputClothings)
                .HasForeignKey(e => e.IdClothingFk),
                j=>{
                    j.ToTable("Input_Clothing");
                    j.HasKey(t => new { t.IdInputFk, t.IdClothingFk});
                });  

            builder.HasMany(i =>i.Suppliers) 
            .WithMany(c => c.Inputs)
            .UsingEntity<InputSupplier>(
                j => j 
                .HasOne(pt => pt.Supplier) //La tabla
                .WithMany(t => t.InputSuppliers) //Relaciona con la tabla
                .HasForeignKey(ut => ut.IdInputFk), //Donde existe un campo:

                j => j
                .HasOne(et => et.Input)
                .WithMany(et => et.InputSuppliers)
                .HasForeignKey(e => e.IdSupplierFk),
                j=>{
                    j.ToTable("Input_Supplier");
                    j.HasKey(t => new { t.IdInputFk, t.IdSupplierFk});
                });      

            
        }

        
    }
