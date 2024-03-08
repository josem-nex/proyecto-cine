using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence;
public class CineDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
    public CineDbContext(DbContextOptions<CineDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}