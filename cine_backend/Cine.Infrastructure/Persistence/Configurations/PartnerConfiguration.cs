namespace Cine.Infrastructure.Persistence.Configurations;

using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PartnerConfigurations : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.ToTable("Partners");
       
        builder.Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Points)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

    }
}