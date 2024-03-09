using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class ShowTimeConfiguration : IEntityTypeConfiguration<ShowTime>
{
    public void Configure(EntityTypeBuilder<ShowTime> builder)
    {
        // builder.Property<int>("MovieId")
        //     .IsRequired();
        // builder.Property<int>("HallId")
        //     .IsRequired();
        // builder.Property<int>("ScheduleId")
        //     .IsRequired();

        // builder.HasKey("MovieId", "HallId", "ScheduleId");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Cost)
            .IsRequired();

        builder.Property(s => s.CostPoints)
            .IsRequired();
    }
}