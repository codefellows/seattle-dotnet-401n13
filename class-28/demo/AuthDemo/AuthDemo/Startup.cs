using AuthDemo.Auth.Models;
using AuthDemo.Auth.Services;
using AuthDemo.Auth.Services.Interfaces;
using AuthDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    public IConfiguration Configuration { get;  }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
      // Add DbContext
      services.AddDbContext<AuthDbContext>(options =>
      {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      // Add Identity Service
      services.AddIdentity<AuthUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<AuthDbContext>();

      // Checks the cookie on login
      services.ConfigureApplicationCookie(options =>
      {
        options.AccessDeniedPath = "/auth/index";
      });

      services.AddTransient<IUserService, IdentityUserService>();

      services.AddAuthentication();
      services.AddAuthorization();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // http://localhost/Food/Pantry == FoodController, Pantry()
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
      });
    }
  }
}
