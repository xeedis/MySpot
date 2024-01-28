using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Infrastructure.DAL.Configurations;

namespace MySpot.Infrastructure.DAL;

internal sealed class MySpotDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<WeeklyParkingSpot> WeeklyParkingSpots { get; set; }

    public MySpotDbContext(DbContextOptions<MySpotDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}