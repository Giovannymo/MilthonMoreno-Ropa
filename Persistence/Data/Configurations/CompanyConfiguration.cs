

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class CompanyConfiguration :IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder){

            builder.ToTable("Company");

            builder.Property(p => p.Nit)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ReasonSocial)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.LegalRepresentative)
            .IsRequired()
            .HasMaxLength(155);

            builder.Property(p => p.DateCreation)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.HasOne(p => p.Municipality)
            .WithMany(p => p.Companies)
            .HasForeignKey(p => p.IdMunicipalityFk);


            
        }

        
    }
