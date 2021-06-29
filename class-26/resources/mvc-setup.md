# Default MVC Application

Below are the directions to scaffold out a stock/core MVC project.

## Set-Up

1. File >> New Project
1. ASP.NET Core Web Application
1. Create a project name (Do not use dashes, only use underscores if needed)
1. Select Empty for the type of web application.
1. Leave everything else as is, and select OK.
1. Go to Startup.cs
1. In `ConfigureServices()` add the appropriate middleware `services.AddMVC()`
1. In `Configure()` add HTTP Pipeline route requirements

```csharp
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
});
```

9. Add app.UseStaticFiles() under `Configure()` after mapping the route to allow the use of static files, such as css and js files.
1. Create a new folder in the project called "Controllers"
1. Create a new folder in the project called "Models"
1. Create a new folder in the project called "Views"
1. If needed, Create a new folder named `wwwroot`
1. Create a new class named `HomeController` in the Controllers Folder
1. Derive `HomeController` from base class Controller (`HomeController:Controller`)
1. Import the appropriate namespace (`Microsoft.AspNetcore.MVC`)
1. Create new action in HomeController named "Index" with a return type of IActionResult
1. Make the return of the `Index()` action `return View()`

```csharp
  public IActionResult Index()
  {
     return View();
  }
```

19. Create a new folder named "Home" in our Views Folder.
1. Create a new .cshtml page in the Home folder that you just created
	a. Right click on Home Folder
	b. Add -> New Item ->
	c. search for "View"
	d. select "Razor View"
	e. Name the View the same page as your action (Keep it Index for this example)
1. Add Text to your Index.cshtml file
1. Run the app and make sure it loads your Home page.
1. If it runs -> YAAY!, if not troubleshoot steps 1-21.

