using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Number).IsRequired();
        builder.Property(s => s.CustomerName).HasMaxLength(100);
        builder.Property(s => s.BranchName).HasMaxLength(100);
        builder.HasMany(s => s.Items).WithOne().HasForeignKey("SaleId").OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("Sales");
    }
}