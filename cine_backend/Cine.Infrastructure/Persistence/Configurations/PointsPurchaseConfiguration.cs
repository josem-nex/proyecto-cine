using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class PointsPurchaseConfiguration : IEntityTypeConfiguration<PointsPurchase>
{
    public void Configure(EntityTypeBuilder<PointsPurchase> builder)
    {
        // builder.Property<int>("PartnerId")
        //     .IsRequired();
        builder.Property<int>("TicketId");
        //     .IsRequired();

        builder.HasKey("UserId", "TicketId");

        builder.Property(p => p.TotalPoints)
            .IsRequired();
    }
}