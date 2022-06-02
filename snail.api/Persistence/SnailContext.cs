using Microsoft.EntityFrameworkCore;
using snail.api.Persistence.Entities;

namespace snail.api.Persistence;

public class SnailContext : DbContext
{
    public SnailContext(DbContextOptions<SnailContext> options) : base(options)
    {
        
    }

    public DbSet<Course>? Courses { get; set; }
    public DbSet<Department>? Departments { get; set; }
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}