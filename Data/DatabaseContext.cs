using Libreforum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libreforum.Data;

public class DatabaseContext : IdentityDbContext<User>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Badge> Badges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Publication>().ToTable("Publications");
        modelBuilder.Entity<Badge>().ToTable("Badges");
    }
}
