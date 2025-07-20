using Microsoft.EntityFrameworkCore;
using TrackR.API.Entities;
using TrackR.Configuration;

namespace TrackR.Context;

public class TrackRDbContext : DbContext
{
    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    public TrackRDbContext(DbContextOptions<TrackRDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
    }
}