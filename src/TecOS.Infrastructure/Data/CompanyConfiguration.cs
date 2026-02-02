using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecOS.Domain.Entities;

namespace TecOS.Infrastructure.Data;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Email).HasMaxLength(150);
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.LogoUrl).IsRequired(false);
        builder.Property(c => c.IsActive).HasDefaultValue(true);
    }
}