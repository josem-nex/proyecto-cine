using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class ChairConfiguration : IEntityTypeConfiguration<Chair>
{
    public void Configure(EntityTypeBuilder<Chair> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Row)
            .IsRequired();

        builder.Property(c => c.Column)
            .IsRequired();

        // builder.HasOne(c => c.Hall)
        //     .WithMany(h => h.Chairs)
        //     .HasForeignKey(c => c.HallId);
    }
}