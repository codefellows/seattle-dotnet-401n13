# Default MVC Application

Below are the directions to scaffold out a bare minimum MVC project. Each project you create will be different given the problem domain, but most of them should start with these steps to get started.

### Set up MVC
1. File >> New Project
1. ASP.NET Core Web Application
1. Create a project name (Do not use dashes, only use underscores if needed)
1. Select Empty for the type of web application
1. Go to Startup.cs
1. In `ConfigureServices()` add the appropriate middleware `services.AddMVC()`
1. In `Configure()` add HTTP Pipeline route requirements

   ```
   app.UseRouting();

   app.UseEndpoints(endpoints =>
   {
	   endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
   });
   ```

8. Add app.UseStaticFiles() under `Configure()` after mapping the route to allow the use of css and js files.
1. Create a new folder in your project called "Controllers"
1. Create a new folder in your project called "Models"
1. Create a new folder in your project called "Views"
1. Create a new folder named `wwwroot`
1. Create a new class named HomeController in the Controllers Folder
1. Derive HomeController from base class Controller (`HomeController:Controller`)
1. Import the appropriate namespace (`Microsoft.AspNetcore.MVC`)
1. Create new action in HomeController named "Index" with a return type of IActionResult
1. Make the return of the `Index()` action `return View()`
1. Create a new folder named "Home" in our Views Folder.
1. Create a new .cshtml page in the Home folder that you just created
	a. Right click on Home Folder
	b. Add -> New Item ->
	c. search for "View"
	d. select "Razor View"
	e. Name the View the same page as your action (Keep it Index for this example)
1. Add Text to your Index.cshtml file
1. Run the app and make sure it loads your Home page.
1. If it runs -> YAAY!, if not troubleshoot steps 1-20.


### Adding Entity Framework Core and a SQL Database:
1. Add Connection Strings to your `appsettings.json` file:
   ```
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DBNAMEHERE;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
1. Change the `DBNAMEHERE` with the name of your Database

1. Change the database name in your newly created connection string.
1. Add a new folder named Data to your project
1. Create a new class in the data folder for your DbContext (i.e. DemoClass13DbContext)
1. Derive your new DbContext class from DbContext (i.e. `DemoClass13DbContext : DbContext`)
   a. Make sure you bring in the namespace Microsoft.EntityFrameworkCore
1. Create a new Constructor for your DbContext class and require the DbContextOptions parameter and have that constructor derive from the base
	 a. Example Constructor looks like this:
   ```
   public DemoClass13DbContext(DbContextOptions<DemoClass13DbContext> options) : base(options)
   {

   }
   ```
1. Go to `Startup.cs`
1. Register our DbContext in our services.
	 a. Inside configureServices() add the following code:(Change out the name of the Context for your DbContext, as well as the "DefaultConnection" with your DefualtConnection name found in your appsettings.json file.
   ```
   services.AddDbContext<DemoClass13DbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
   );
   ```
1. We now setup our app to support dependency injection, we do this by adding a configuration property along with a constructor to our startup class that requires IConfiguration. This is the code for that:
   ```
   public IConfiguration Configuration { get; }

   public Startup(IConfiguration configuration)
   {
     Configuration = configuration;
   }
   ```
1. Add a new property named Configuration that is of type IConfiguration.
1. Make sure you have added the following using statement:
   ```
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   ```
1. Open up Package Manager Console.
   1. Run the following Commands
      1. Add an initial migration to your project. Run the following command in PMC
	       - `Add-Migration initial`
      1. After adding a migration, update your database:
         - `Update-Database`

### MISC

1. When you start adding tables, make sure you do so in the DBContext file by adding a new `DBSet`.
A DbSet would look like this:
   ```
   public DbSet<MODELNAME> TABLENAME {get; set;}
   ```
1. Make sure that you add a new migration and update the database after every major change you make.


