

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class EmployeeConfiguration :IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder){

            builder.ToTable("Employee");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.JoinDate)
            .IsRequired()
            .HasColumnType("DateTime");
            
            builder.HasOne(p => p.JobTitle)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.IdJobTitleFk);

            builder.HasOne(p => p.Municipality)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.IdMunicipalityFk);
            


            
        }

        
    }
