# Swagger Quickstart

The following steps help us to create live documentation using Swagger definitions.


1. Install Dependency: Swashbuckle.AspnetCore
1. In `Startup.cs`, configure a new service dependency
   ```csharp
   public void ConfigureServices()
   {
     ...
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
   ```
1. Create the new routes so that swagger "works"
1. In `Startup.cs`, add this to `Configure()`
   ```csharp
   app.UseSwagger( options => {
    options.RouteTemplate = "/api/{documentName}/swagger.json";
   });
   ```
   - `documentName` is the `version` you gave in the previous step


Now ...

https://localhost:PORT/api/v1/swagger.json

Boom! You get a fully configured Swagger compatible JSON definition.

You can plug this directly into Swagger.io and see your live API


## Even better, let's serve our own docs...

```csharp
app.UseSwaggerUI( options => {
  options.SwaggerEndpoint("/api/v1/swagger.json", "Student Demo");
  options.RoutePrefix = "docs";
});
```

Now ...

http://localhost:PORT/docs is the actual documentation for your API.

You can set `RoutePrefix` to "" to make your API Documentation the Home Page for your API

