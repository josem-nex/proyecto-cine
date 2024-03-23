using Cine.Domain.Entities;
using Cine.Domain.Entities.Movies;
using Cine.Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence;
public class CineDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<ShowTime> ShowTimes { get; set; } = null!;
    public DbSet<Schedule> Schedules { get; set; } = null!;
    public DbSet<Hall> Halls { get; set; } = null!;
    public DbSet<Chair> Chairs { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Discount> Discounts { get; set; } = null!;
    public DbSet<MonetaryPurchase> MonetaryPurchases { get; set; } = null!;
    public DbSet<PointsPurchase> PointsPurchases { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    public CineDbContext(DbContextOptions<CineDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}