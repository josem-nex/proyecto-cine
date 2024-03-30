/* using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class MonetaryPurchaseConfiguration : IEntityTypeConfiguration<MonetaryPurchase>
{
    public void Configure(EntityTypeBuilder<MonetaryPurchase> builder)
    {
        // builder.Property<int>("UserId");
        builder.Property<int>("TicketId");

        builder.HasKey("UserId", "TicketId");

        builder.Property(p => p.CreditCard)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.TotalPrice)
            .IsRequired();

    }
} */

using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class ScheduleHallConfiguration : IEntityTypeConfiguration<ScheduleHall>
{
    public void Configure(EntityTypeBuilder<ScheduleHall> builder)
    {
        builder.HasKey(sh => new { sh.SchedulesId, sh.HallsId });
    }
}