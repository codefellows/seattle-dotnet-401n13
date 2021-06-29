using CookiesDemo.Auth.Models;
using CookiesDemo.Auth.Services;
using CookiesDemo.Auth.Services.Interfaces;
using CookiesDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CookiesDemo
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    // 1. Add a property to hold our configuration
    public IConfiguration Configuration { get; }

    // 2. Add a constructor to receive our condfiguration (through some magic)
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddMvc();

      services.AddDbContext<DemoDbContext>(options =>
      {
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      services.AddIdentity<AuthUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      })
      .AddEntityFrameworkStores<DemoDbContext>();

      // Alternative to JWT, use the built-in authentication system
      services.AddAuthentication();

      // Policies
      services.AddAuthorization(options =>
      {
        // Add "Name of Policy", and the Lambda returns a definition
        options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
        options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
        options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
        options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
      });

      services.AddTransient<IUserService, IdentityUserService>();


      services.ConfigureApplicationCookie(options =>
      {
        options.AccessDeniedPath = "/login/index";
      });

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
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
      });
    }
  }
}
