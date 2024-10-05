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
        base.OnModelCreating(modelBuilder);
    }
}