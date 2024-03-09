using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        // builder.Property<int>("ShowTimeId")
        //     .IsRequired();
        // builder.Property<int>("ChairId")
        //     .IsRequired();
        // builder.HasKey("ShowTimeId", "ChairId");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.IsWeb)
            .IsRequired();

    }
}