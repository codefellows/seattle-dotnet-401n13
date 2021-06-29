# Deployment

1. Create an Azure Account
1. Create a "Subscription"
1. Right click your app, and choose "Publish"
1. Follow the wizard
   - Database Creation
   - Username/Password
   - Deployment Slots, etc

Things to focus on:

- App Services
- App Components at Azure
- Deployment Process

When you're all done, hit the website given.

The basics will work, API will not because of Migration.

This is a good time to show students how to add an Env Variable to the app. Notice that the 500 error gives no information. If we add this env var, we can see the developer page:

`ASPNETCORE_Environment=Development`


## Auto-Migrate on start

Change your `Program.cs` file from this:

```csharp
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }
```

To This:

```csharp
public static void Main(string[] args)
{
  var host = CreateHostBuilder(args).Build();

  UpdateDatabase(host.Services);

  host.Run();
}

private static void UpdateDatabase(IServiceProvider services)
{
  using (var serviceScope = services.CreateScope())
  {
    using (var db = serviceScope.ServiceProvider.GetService<SchoolDbContext>())
    {
      db.Database.Migrate();
    }
  }
}

/*
 * The above can also be written like this, which is far cleaner, yet less explicit, without the nesting
 *
 * using var serviceScope = services.CreateScope();
 * using var db = serviceScope.ServiceProvider.GetService<SchoolDbContext>()
 * db.Database.Migrate();
 *
 */

```

### What are those `using` statements?

At the top of file, we have `using` declarations, which declare the dependencies our module needs to "use"

Using statements say "I have a thing I want you to clean up when you're done" ... essentially, here we are creating a temporary scope in which to run our Migration and then have that temp DbContext go away in favor of what the app will actually use.
