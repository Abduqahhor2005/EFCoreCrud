using EFCoreCrud.DataConfig;
using EFCoreCrud.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCrud.DataContext;

public sealed class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}