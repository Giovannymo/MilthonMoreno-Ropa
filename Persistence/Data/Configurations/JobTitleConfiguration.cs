using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

    public class JobTitleConfiguration :IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder){

            builder.ToTable("Job_Title");

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(155);

            builder.Property(p => p.BaseSalary)
            .IsRequired()
            .HasColumnType("double");

            
        }

        
    }
