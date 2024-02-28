using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class RepositoryDbContext : DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Barber> Barbers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public RepositoryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);

        modelBuilder.Entity<Barber>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Appointment>().HasQueryFilter(x => !x.IsCanceled);
    }

}
