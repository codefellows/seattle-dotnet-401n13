using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
  public class SchoolDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // This calls the base method, but does nothing
      // base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Student>().HasData(
        new Student { Id = 1, FirstName = "John", LastName = "Cokos" }
      );
    }
  }

}
