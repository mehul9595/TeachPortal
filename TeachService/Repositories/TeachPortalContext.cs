// TeachService.Repositories/TeachPortalContext.cs
namespace TeachService.Repositories;

/// <summary>
/// Represents the database context for the teaching portal.
/// </summary>
public class TeachPortalContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TeachPortalContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public TeachPortalContext(DbContextOptions<TeachPortalContext> options) : base(options) { }

    /// <summary>
    /// Gets or sets the collection of teachers.
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; }

    /// <summary>
    /// Gets or sets the collection of students.
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// Configures the schema needed for the context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Students)
            .WithOne(s => s.Teacher)
            .HasForeignKey(s => s.TeacherId);
    }
}
