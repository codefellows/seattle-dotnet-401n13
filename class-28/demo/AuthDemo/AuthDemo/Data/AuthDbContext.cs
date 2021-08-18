using AuthDemo.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Data
{
  public class AuthDbContext : IdentityDbContext<AuthUser>
  {

    public AuthDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<IdentityRole>().HasData(
        new IdentityRole {  Id="administrator", Name="Administrator", NormalizedName="ADMINISTRATOR", ConcurrencyStamp=Guid.Empty.ToString() },
        new IdentityRole {  Id="editor", Name="Editor", NormalizedName="EDITOR", ConcurrencyStamp=Guid.Empty.ToString() },
        new IdentityRole {  Id="guest", Name="Guest", NormalizedName="GUEST", ConcurrencyStamp=Guid.Empty.ToString() }
      );

    }

  }
}
