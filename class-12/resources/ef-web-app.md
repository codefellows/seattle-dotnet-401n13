# Entity Framework Setup Guide

1. Create and Scaffold an ASP.net web application
1. Install and configure Entity Framework
1. Connect to a SQL Database
1. Create some basic data models/tables
1. Create a table with some "seed" data
1. Identify relations between tables

## Phase 1: Create and Scaffold a Basic Web Project

In this first phase, we'll get a basic ASP.net app installed and do a quick tour of its parts, basic routing, and get acquainted with the default system.

- [ ] Type: ASP.net Core Web App
- [ ] DO NOT check the "Place solution in same folder" box
- [ ] Choose Empty Project
  - Note: There are others that are more baked/template-ized
- [ ] "Run" it. Note the "Hello World" in the browser
  - We're getting a lot of automatic goodness from Visual Studio here

### Program.cs

- [ ] Walk through the "Startup Sequence"
  - This effectively does what `app.listen()` did in express
  - We will rarely change this much or often

### Startup.cs

- [ ] `Configure()`
  - This is where we'll be setting up our rotes and branching logic
  - (Think `app.use()` from Express)
  - Note the similarities between this and Express with regards to handling a request and response
- [ ] Create a new get route to prove that it works (i.e. `/hey`)
- [ ] Alter this route to throw an exception instead of a response to show how the `env.IsDevelopment()` block works
  - `throw new InvalidOperationException("booyah")`

## Phase 2: Setup Entity Framework

This will allow for us to connect to our database

### Install the Entity Framework Dependencies for your app

#### Visually

- [ ] In **Solution Explorer**, right-click project **Dependencies** and pick **Manage NuGet Packages...**
- [ ] `Microsoft.EntityFrameworkCore.SqlServer`
- [ ] `Microsoft.EntityFrameworkCore.Tools`

#### With Package Manager Console

- [ ] `Install-Package Microsoft.EntityFrameworkCore.SqlServer`
- [ ] `Install-Package Microsoft.EntityFrameworkCore.Tools`

#### With `dotnet`

- [ ] `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- [ ] `dotnet add package Microsoft.EntityFrameworkCore.Tools`

### Install `ef` command line tool

From a terminal, run these commands. Once verified, you can use the command line to issue Entity Framework commands

- [ ] `dotnet tool install --global dotnet-ef`
- [ ] `dotnet ef`

## Phase 3: Connect to a database

### Create a `DbContext`, which allows us to communicate with Entity Framework

- [ ] Add a folder called `Data`
- [ ] Within, Add a new class called `SchoolDbContext.cs` that inherits from `DbContext`, with a generated constructor with options

  ```csharp
  public class SchoolDbContext : DbContext
  {
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }
  }
  ```

- [ ] Update/Initialize Database fails with "Unable to create object of type"
  - Terminal: `dotnet ef database update`
  - Package Manager Console: `Update-Database`

### Alter `Startup.cs` to prepare a configuration & connection with this DbContext

- [ ] Add a property to hold our configuration

  ```csharp
  public IConfiguration Configuration {get;}
  ```

- [ ] Add a constructor to receive our configuration (a bit of magic here)

   ```csharp
   public Startup(Iconfiguration configuration)
   {
     Configuration = configuration;
   }
   ```

- [ ] Register our DbContext with the app within ConfigureServices()
  - `services.AddDbContext()` is called as a generic with our DbContext as the type
  - This will allow us to set options, such as connecting to our SQL Server

  ```csharp
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDbContext<SchoolDbContext>( options => {
     // Our DATABASE_URL from js days
     string connectionString = Configuration.GetConnectionString("DefaultConnection");
     options.UseSqlServer(connectionString);
    });
  }
  ```

- [ ] Apply migrations again, and you should see a big error talking about the Connection String
      - Terminal: `dotnet ef database update`
      - Package Manager Console `Update-Database`
- [ ] Finally, add the actual connection string to the `appsettings.json` file
  - Change **DBNAMEHERE** to the name of the database for your project

  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DBNAMEHERE;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
  }
  ```

- [ ] Apply migrations again ...
  - You should see "Done." ... indicating your app is connected to a running local SQL Server
- [ ] Open **View > SQL Server Object Explorer**
- [ ] Navigate to the `(localdb)` Server and browse to find your database

## Phase 4: Data Models and SQL Tables

Now, we create C# Classes that automagically link to and become database tables

### Add Basic Models

- [ ] Create a folder called `Models"
- [ ] Create a class for one of our ERD entities (`Student.cs`)
- [ ] Include their properties from the ERD
- [ ] Add A `DbSet` to the `DbContext` for this model

  ```csharp
  // there should be a students table with student records in it.
  public DbSet<Student> Students { get; set; }
  ```

- [ ] Create a "Migration"
  - Terminal: `dotnet ef migrations add AddStudentsTable`
  - Package Manager Console `Add-Migration AddStudentsTable`
  - Lots of things just happened:
    - [ ] In the Migrations folder, we find a set of instructions for building a SQL Table
      - Each model change requires a new migration
      - These are time stamped, so we can run them in series
      - This allows us to move from local to production with change
- [ ] Apply that migration to the database
  - Terminal: `dotnet ef database update`
  - Package Manger Console: `Update-Database`
- [ ] Let's change our student table to make FirstName and LastName required using an annotation
  - `[Required]`
  - This will require us to repeat the Migration and Update steps, since we changed it
  - Note the ordering of the migration files
  - Dig into the migration file and see the commands generated

### Add Table with some seed data

- [ ] Add class for Technologies
- [ ] Add the `DbSet` to the `DbContext` (every time)
- [ ] Add an override to `OnModelCreating`

  ```csharp
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // This calls the base method, but does nothing
    // base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Technology>().HasData(
      new Technology { Id = 1, Name = ".NET " },
      new Technology { Id = 2, Name = "Node.js" }
    );
  }
  ```

- [ ] Create a new migration and update the database
  - Dig into the migration file and see the commands generated
- [ ] Navigate to SQL Explorer and see the new table, with records in it

## Phase 5: API Routes

- [ ] Add a folder called `Controllers`
- [ ] Right-lick the folder and choose **Add > Controller...**
- [ ] Choose **Common > API** and add **API Controller with actions, using Entity Framework**
- [ ] Use the wizard, follow the prompts
- [ ] Call it `TechnologiesController`
- [ ] Visual Studio will create the controller class for you
- [ ] Add the "Controllers" services to the `ConfigureServices()` in `Startup.cs`

  ```csharp
  services.AddControllers();
  ```

- [ ] Add controller mapping inside the `app.UseEndpoints()` declaration, above `endpoints.MapGet("/", …)`

  ```csharp
  endpoints.MapControllers();
  ```

- [ ] Start your application
- [ ] Browse to `/api/Technologies` to see the data we seeded into that model
