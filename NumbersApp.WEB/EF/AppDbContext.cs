using Microsoft.EntityFrameworkCore;
using NumbersApp.WEB.EF.Entities;
using System.Reflection;

namespace NumbersApp.WEB.EF;

public class AppDbContext : DbContext
{
    public DbSet<Number> Numbers => Set<Number>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}