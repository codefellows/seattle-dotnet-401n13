using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolAPI.Data;
using SchoolAPI.Models;
using SchoolAPI.Models.Interfaces;
using SchoolAPI.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
  public class Startup
  {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<SchoolDbContext>(options =>
      {
        // Our DATABASE_URL from js days
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      // SWAGGER: Definition Generator
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "School Demo",
          Version = "v1",
        });
      });

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        // Other things are possible
        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<SchoolDbContext>();

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

      services.AddAuthorization(options =>
      {
        // Add "Name of Policy", and the Lambda returns a definition
        options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
        options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
        options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
      });




      // This map the dependency (IStudent) to the correct service (StudentService)
      // "Whenever I see "IStudent" use "StudentService"
      // This means that I can swap out StudentService for ANYTHING
      // services.AddTransient<IStudent, StudentServiceViaMongo>();
      services.AddTransient<IStudent, StudentService>();
      services.AddTransient<ICourse, CourseService>();
      services.AddTransient<ITechnology, TechnologyService>();
      services.AddTransient<IUser, IdentityUserService>();
      services.AddScoped<JwtTokenService>();

      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      // SWAGGER - JSON DEFINIION
      app.UseSwagger(options => {
        options.RouteTemplate = "/api/{documentName}/swagger.json";
      });

      // SWAGGER: Interactive Documentation
      app.UseSwaggerUI(options => {
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
