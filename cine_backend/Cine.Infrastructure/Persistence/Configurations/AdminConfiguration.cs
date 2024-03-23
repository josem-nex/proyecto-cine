namespace Cine.Infrastructure.Persistence.Configurations;

using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id,
                id => id);
        builder.Property(u => u.User)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(50);

    }
}