using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Data
{
  public class DemoDbContext : DbContext
  {

    public DemoDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Person>().HasData(
        new Person { Id = 1, Name = "John", Age = 52 },
        new Person { Id = 2, Name = "Cathy", Age = 50 },
        new Person { Id = 3, Name = "Zach", Age = 22 },
        new Person { Id = 4, Name = "Allie", Age = 15 }
      );
    }

    public DbSet<Person> People { get; set; }
  }
}
