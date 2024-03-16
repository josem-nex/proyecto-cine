using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cine.Infrastructure.Persistence.Configurations;
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(a => a.Director)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.ReleaseDate)
            .IsRequired();

        builder.Property(a => a.Language)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Rating)
            .IsRequired();

    }
}