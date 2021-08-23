using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPages.Data;
using RazorPages.Services;
using RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration config)
    {
      Configuration = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<DemoDbContext>(options =>
      {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

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
        // Order of operations: Check for a Razor Page
        endpoints.MapRazorPages();
        // Otherwise, try and find an MVC route
        endpoints.MapControllerRoute("default", "{controller=Dashboard}/{action=Index}");
      });
    }
  }
}
