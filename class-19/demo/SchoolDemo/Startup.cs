using SchoolDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Services.Interfaces;
using SchoolDemo.Services;
using Microsoft.OpenApi.Models;
using SchoolDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SchoolDemo
{
  public class Startup
  {
    // 1. Add a property to hold our configuration
    public IConfiguration Configuration { get; }

    // 2. Add a constructor to receive our condfiguration (through some magic)
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This is very similar to what dotenv did for us in NodeJS
    public void ConfigureServices(IServiceCollection services)
    {
      // 3. Register our DbContext with the app
      services.AddDbContext<SchoolDbContext>(options =>
      {
        // Equivalent to DATABASE_URI
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
        // There are other options like this
      })
      .AddEntityFrameworkStores<SchoolDbContext>();

      // Bring in our JWT Token Service
      services.AddScoped<JwtTokenService>();

      // Add the wiring for adding "Authentication" for our API
      // "We want the system to always use these "Schemes" to authenticate us
      services.AddAuthentication(options =>
        {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
          {
            // Tell the authenticaion scheme "how/where" to validate the token + secret
            options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
          });

      // Policies
      services.AddAuthorization(options =>
        {
          // Add "Name of Policy", and the Lambda returns a definition
          options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
          options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
          options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
        });


      // Register my Dependency Injection services
      // This mapps the Dependency (IStudent) to the correct Service (StudentRepository)
      // "Whenever I see IStudent, use StudentRepository
      // This makes StudentRepository swappapble with any alternate implementation
      services.AddTransient<ICourse, CourseService>();
      services.AddTransient<IStudent, StudentService>();
      services.AddTransient<ITechnology, TechnologyService>();
      services.AddTransient<IUserService, IdentityUserService>();

      // Bring in our controllers
      services.AddMvc();
      services.AddControllers();


      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddSwaggerGen(options =>
      {
        // Make sure get the "using Statement"
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "School Demo",
          Version = "v1",
        });
      });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseSwagger(options =>
      {
        options.RouteTemplate = "/api/{documentName}/swagger.json";
      });

      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/api/v1/swagger.json", "Student Demo");
        options.RoutePrefix = "";
      });

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
