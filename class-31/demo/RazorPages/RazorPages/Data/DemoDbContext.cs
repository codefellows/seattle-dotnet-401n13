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

    // Constructor to kick off the base with options
    public DemoDbContext(DbContextOptions options) : base(options) { }


    // db set --- declaring our model
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
      model.Entity<Person>().HasData(
        new Person { Id = 1, Name = "John", Age = 52 },
        new Person { Id = 2, Name = "Cathy", Age = 50 }
      );
    }

  }
}
