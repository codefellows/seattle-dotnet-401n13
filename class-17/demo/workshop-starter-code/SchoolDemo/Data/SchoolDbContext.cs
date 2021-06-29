using SchoolDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Data
{
  public class SchoolDbContext : DbContext
  {
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // This calls the base method, but does nothing
      // base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Technology>().HasData(
        new Technology { Id = 1, Name = ".NET " },
        new Technology { Id = 2, Name = "Node.js" }
      );

      // This creates the composite primary key for the enrollments table
      modelBuilder.Entity<Enrollment>().HasKey(
        // Create a new "anonymous" type (like a JS object)
        enrollment => new { enrollment.CourseId, enrollment.StudentId }
      );
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }

    // This will fail the first time when you try to make a migration because there's no primary key (id)
    // Do a modelbuilder override, and then add it
    public DbSet<Enrollment> Enrollments { get; set; }
  }
}
