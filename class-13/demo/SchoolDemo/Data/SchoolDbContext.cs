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
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Technology> Technologies { get; set; }
  }
}
