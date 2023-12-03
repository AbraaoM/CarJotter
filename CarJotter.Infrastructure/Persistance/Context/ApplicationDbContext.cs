using Microsoft.EntityFrameworkCore;
using CarJotter.Core.Entities;

namespace CarJotter.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CarEntity> Cars { get; set; } = null!;
    public DbSet<ProcedureEntity> Procedures { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
