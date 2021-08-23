using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPages.Data;
using RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
  public class Startup
  {
    // Properties
    public IConfiguration Config { get;  }

    // Constructor
    public Startup( IConfiguration c )
    {
      Config = c;
    }

    // Methods
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddMvc();

      // Connect to our DbContext

      services.AddDbContext<DemoDbContext>(options =>
      {
        string connectionString = Config.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      // Expose our services for DI
      services.AddTransient<IPerson, PeopleService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        // Try and find a razor page if you can
        endpoints.MapRazorPages();

        // Or, just get an MVC Page if that matches
        endpoints.MapControllerRoute("default", "{controller=Dashboard}/{action=Index}");
      });
    }
  }
}
