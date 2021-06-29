# Lecture 13: Intro to Entity Framework


### Three Take-a-ways
1. What is the purpose of Entity Framework
1. What is a Code First Migration
1. How do you show composite key relationships in MVC Core.


## Review MVC Life Cycle
Talk about what each of the MVC components look like. do the drawing from class 11 again if needed.

Scaffold out, from an empty web app, an MVC web app. Don't add the models yet though, as those will tie directly into today's lecture.

#### Demo
1. Scaffold out an empty MVC Site with a Home controller
1. Look at the ERD of the DB Schema.
1. Convert each entity of the ERD to a Model class in your code.
   - "accidentally" forget to add the Primary keys (the ids)
    - Don't add nav properties just yet

## Entity Framework
1. What is Entity Framework?
1. Why do we use it?

EF Core can serve as an object-relational mapper (O/RM), enabling .NET developers to work with a database using .NET objects, and eliminating the need for most of the data-access code they usually need to write.

EFCore allows us to make calls and queries to our database through this ORM allowing for efficiency and ease of use.

[EF Core](https://docs.microsoft.com/en-us/ef/core/)

### Adding a Database Connection
1. Create a DbContext
1. Add the constructor
1. Create the DBSets for the tables

Be sure to talk about what the constructor is doing (the base class also has a constructor, which is why we have base(options)).

Now try and script out the models to build the database. **Your are going to get an error....**

At this point, try to create a migration. You will get a misleading error.

- Terminal: `dotnet ef migrations add AddStudentsTable`
- Package Manager Console `Add-Migration AddStudentsTable`

All this means that you haven't registered the DB Context yet...so let's do that...

1. Register the DBContext in Startup

   ```csharp
   services.AddDbContext<EnrollmentDbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
   );
   ```

1. Add the `ConnectionStrings` value into the `appsettings.json` file

During the registration of your DBContext, you will have to set you app up for Dependency Injection, meaning you need to add a constructor to the startup file and bring in `IConfiguration`. You can explain to them at a high level what this is doing (The service provider is bringing in the default configurations into the app), but we will talk more about it on Day 16 with DI.

Now, try to create the migration again. You will get another error that you didn't add primary keys to some of the models.

Go back and add the `ID` properties to the Transcripts, Students, and Courses.
You also need to register the composite key binding in the DBContext.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Binding of the Composite Key using FluentAPI
    modelBuilder.Entity<Enrollments>().HasKey(enrollment =>
    new { enrollment.StudentID, enrollment.CourseID });
}
```

After you add the composite key, don't forget to go back and add the navigation properties.

Talk about the connections between the nav properties and why we need them.

Now create your initial migration one last time, and watch the magical database scripts get created:

- Terminal: `dotnet ef migrations add AddStudentsTable`
- Package Manager Console `Add-Migration AddStudentsTable`

Review the scripts. talk about what migrations are and what is being generated.

Apply the migration and confirm creation of the database:

- Terminal: `dotnet ef database update`
- Package Manager Console `Update-Database`

### Shadow Properties

Shadow properties are properties that are not in the .NET entity class, but are in the EFCore model.

This is useful when the properties need not be exposed, but only for mapping purposes. Most ofen are used as foreign keys.

[Shadow Properties](https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties)

### Fluent API

You use FluentAPI to configure shadow properties. The Fluent API allows us to make changes to the EFCore model directly. There are some changes that can only be made through the FluentAPI and not through Data Annotations.

[Fluent API](https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties#fluent-api)
