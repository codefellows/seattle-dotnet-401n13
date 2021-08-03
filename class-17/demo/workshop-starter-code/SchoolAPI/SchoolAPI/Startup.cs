using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolAPI.Data;
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

      // This map the dependency (IStudent) to the correct service (StudentService)
      // "Whenever I see "IStudent" use "StudentService"
      // This means that I can swap out StudentService for ANYTHING
      // services.AddTransient<IStudent, StudentServiceViaMongo>();
      services.AddTransient<IStudent, StudentService>();
      services.AddTransient<ICourse, CourseService>();
      services.AddTransient<ITechnology, TechnologyService>();

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

      app.UseEndpoints(endpoints =>
      {

        endpoints.MapControllers();

        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Hello World!");
              });
      });
    }
  }
}
