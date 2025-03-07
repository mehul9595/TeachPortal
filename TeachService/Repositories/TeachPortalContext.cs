// TeachService.Repositories/TeachPortalContext.cs
using Microsoft.EntityFrameworkCore;
using TeachService.Models;

namespace TeachService.Repositories;

public class TeachPortalContext : DbContext
{
    public TeachPortalContext(DbContextOptions<TeachPortalContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Students)
            .WithOne(s => s.Teacher)
            .HasForeignKey(s => s.TeacherId);
    }
}
