# Demos: Roles, Claims and JWT Tokens

Use this document to describe the demo(s). Generally, this is going to take the format of either how to build the demo step by step, or less specifically, talking points surrounding the outcomes of the demo segment and code snippets to highlight.

## Bearer Auth

- Wire up JWT Service
- Be able to "Create" a token
  - Send this out when we create a user or someone logs in
- Be able to "Read" a token
- Apply [Authorization] to any route when they present a previously given token
  - This will restrict access

> Dependency: Microsoft.AspNetCore.Authentication.JwtBearer

### Wire up a basic **JWT Token Service**

1. New Service Class: `JwtTokenService`
   - This will be responsible for all things related to JWT Tokens
1. Register our new service in startup
   - Note: No Interface here, just the service itself, which will be very limited in scope
   - `services.AddScoped<JwtTokenService>();`
1. Also, add the `JwtTokenService` as a dependency of our `IdentityUserService`
   - Ref: `Services/IdentityUserService.cs`

   ```csharp
   public class IdentityUserService : IUserService
   {
     private UserManager<ApplicationUser> userManager;
     private JwtTokenService tokenService;

     public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
     {
       userManager = manager;
       tokenService = jwtTokenService;
     }
     ...
   ```

Given that everything is "wired up", now is a good time to start the server and check our Register/Login routes again, so that we know we didn't break anything.

### More wiring: Setup "Secret" Validation in the JWT service and add to the App Configuration

1. Ref: `Services/JwtTokenService.cs`

   ```csharp
    // Validate that our "secrets" are actually secrets and that they match
    // This will be used by the validator
    public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
    {
      return new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        // This Is Our main goal: Make sure the security key, which comes from configuration is valid
        IssuerSigningKey = GetSecurityKey(configuration),

        // For simplifying testing
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    }

    private static SecurityKey GetSecurityKey(IConfiguration configuration)
    {
      var secret = configuration["JWT:Secret"];
      if (secret == null) { throw new InvalidOperationException("JWT:Secret is midding"); }
      var secretBytes = Encoding.UTF8.GetBytes(secret);
      return new SymmetricSecurityKey(secretBytes);
    }
   ```

1. Once we have the ability to validate secrets, we'll need to add the Authentication Service
   - Ref: `ConfigureServices` in `Startup.cs`
   - This is very much boilerplate, so it's ok to see this as "Copy/Paste"

   ```csharp
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

   ```

1. Finally, tell our app to use these services
   - Ref: `Configure()` in `Startup.cs`

   ```csharp
   app.UseAuthentication();
   app.UseAuthorization();
   ```

### Get/Create Token for a User when they login

As you create these, reference jwt.io, to see where these things are used in a real token

```csharp
public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
{
  var principal = await signInManager.CreateUserPrincipalAsync(user);
  if(principal == null) { return null; }

  var signingKey = GetSecurityKey(configuration);
  var token = new JwtSecurityToken(
    expires: DateTime.UtcNow + expiresIn,
    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
    claims: principal.Claims
   );

   return new JwtSecurityTokenHandler().WriteToken(token);
}
```

Now, we have a way to make a token for a user. Let's plug this in -- we want to give this to every user when they login successfully or register.

In our **UserDto.cs**, let's add a `Token` field, and in the UserService, add that when we present the object

```csharp
public string Token {get; set;}
```

Then, in the **IdentityUserService.cs**, add the token to our Dto output:

```csharp
return new UserDto
{
  Id = user.Id,
  Username = user.UserName,
  Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
};
```

> Run the server and login with your id, and see if you get a token!

- Do you see the Error related to the JWT Secret being missing?
- Add that to your appsettings.json and then try again

  ```json
  ...
  "JWT": {
    "Secret":"asdlfjasdf98asdf08asdf8"
  }
  ...
  ```

At this point, you should have a token. Inspect it and witness the "claims" ... any application that can read JWTs can see and use this token. Generally, this is

### Use the token to Login instead of sending Username+Password

1. Setup a `GetUser()` method for the IdentityUserService that takes in a "ClaimsPrincipal"
   - This will effectively be the way that we can turn those "Claims" into a User

   ```csharp
    // Use a "claim" to get a user
    public async Task<UserDto> GetUser(ClaimsPrincipal principal)
    {
      var user = await userManager.GetUserAsync(principal);
      return new UserDto
      {
        Id = user.Id,
        Username = user.UserName
      };
    }
   ```

1. Create a route in the controller that will allow you to "Get Yourself"

   ```csharp
   // Whoa! New annotation that will be able to Read the bearer token
   // and return a user based on the claim/principal within...
   [Authorize]
   [HttpGet("me")]
   public async Task<ActionResult<UserDto>> Me()
   {
     // Following the [Authorize] phase, this.User will be ... you.
     // Put a breakpoint here and inspect to see what's passed to our getUser method
     return await userService.GetUser(this.User);
   }
   ```

> **[Authorize]** is an annotation that lets us "protect" any route to ensure that the user is validated. Remember, the "token" **is** the user. You can also [Authorize] the whole controller and then [AllowAnoymous] on individual routes

Can you edit/modify the token by hand? Sure (try it at jwt.io) ... But it'll fail muster.

## Roles

1. Seed some data in our DbContext
   - Some things, like these roles, will remain constant, so it's fine to pre-fill our database with them.
   - Create a helper method that creates Identity roles and then uses the `.HasData()` method to put those into the database as we did with the other models.
   - Ref: SchoolDbContext.cs

   ```csharp
   SeedRole(modelBuilder, "Administrator");
   SeedRole(modelBuilder, "Editor");
   private void SeedRole(ModelBuilder modelBuilder, string roleName)
   {
     var role = new IdentityRole
     {
       Id = roleName.ToLower(),
       Name = roleName,
       NormalizedName = roleName.ToUpper(),
       ConcurrencyStamp = Guid.Empty.ToString()
     };
     modelBuilder.Entity<IdentityRole>().HasData(role);
   }
   ```

   - Run a migration to get these roles inserted into the Database
1. Update the `Register` route in the controller to let us add a role
   - Note: This is bad practice. Normally, this would be a manual or automated process. Users cannot just "decide" to be an "Administrator"
   - Add them to the roles table
   - Add their roles to the DTO (and copy that addition around, and into the DTO itself)
   - Ref: UsersController.cs `Register()`

   ```csharp
   if (result.Succeeded)
     {
       // Because we have a "Good" user, let's add them to their proper role
       await userManager.AddToRolesAsync(user, data.Roles);
       return new UserDto
       {
         Id = user.Id,
         Username = user.UserName,
         Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
         Roles = await userManager.GetRolesAsync(user)
       };
     }
   ```

   - Launch the app and add a new user, with a role specified

### Further protecting our routes ...

`[Authorize(Roles="administrator")]`

Yep. That's it.

Play around by adding that decorator to various routes with different roles being specified and see what your user can and cannot access.

## POLICIES

Register a role based policy

What we want to be able to do in a route is something like this ... which takes the "role" a level deeper, as many roles can share policies

> [Authorize(Policy="create")]

1. First thing we want to do is to enable this in our web application. Let's add the following code to `ConfigureServices` method in our `Startup.cs` file:

```csharp
services.AddAuthorization(options =>
  {
    // Add "Name of Policy", and the Lambda returns a definition
    options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
    options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
    options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
  });
```

1. Next, let's modify the DbContext to be able to identify the "claims" on the roles as we seed them
   - First, let's write out the code we'd like to be able to implement

   ```csharp
   SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
   SeedRole(modelBuilder, "Editor", "create", "update");
   SeedRole(modelBuilder, "Writer", "create");
   ```

   - Next, we'll alter the `SeedRole` method to allow that.
     - Notice the use of `params string[]` to handle the multiple inbound params

     ```csharp

     private int nextId = 1; // we need this to generate a unique id on our own
     private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
     {
       var role = new IdentityRole
       {
         Id = roleName.ToLower(),
         Name = roleName,
         NormalizedName = roleName.ToUpper(),
         ConcurrencyStamp = Guid.Empty.ToString()
       };

       modelBuilder.Entity<IdentityRole>().HasData(role);

       // Go through the permissions list (the params) and seed a new entry for each
       var roleClaims = permissions.Select(permission =>
       new IdentityRoleClaim<string>
       {
         Id = nextId++,
         RoleId = role.Id,
         ClaimType = "permissions", // This matches what we did in Startup.cs
         ClaimValue = permission
       }).ToArray();

       modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
     }
     ```

1. Because we altered the DbContext, we need to migrate and update the database

### Validate

1. Delete all of your users
1. Add new users with admin, editor, writer permissions
1. Add a series of varying Authorization annotations on the routes, and login as different users
1. With each user's bearer token you should be permitted or denied access to various things
