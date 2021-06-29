# How to add User Secrets to .NET Core through Visual Studio

What is User secrets? User secrets is a secure way of storing private user information
such as API keys, client secrets, and connection strings. Essentially anything that you 
don't want others to know about when using your code base. 

The user secrets is not uploaded to any source control. This ensures your keys do in fact stay "secret" to your local machine. 

## Enabling User Secrets

Your first step is to enable User Secrets in your project. To do this, follow these steps:
1. Right click on your project
2. Select "Manage User Secrets"

This will open up a secrets.Json file in your Visual studio. Yours will be empty, but
all it is, is a JSON key/value pair file. This should mimic your `appsettings.json` file.

```
{
  "myBingAPIKey": "{VALUE}",
  "textAPIKey": "{VALUE}",
  "ConnectionStrings": {
    "AzureConnection": "{CONNECTION STRING HERE}"
}
```
This file is NOT stored in your local repo. In fact 
(depending on your local environment) it is located at  

`%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json.`



Next, you need to open your `.csproj` file. To do this follow these steps:
1. Right click on your project and select "Edit xxx.csproj file" (the xxx will be the name of your project)


Because you opened the `secrets.json` first, you should have a 
user secret ID line added in the propertyGroup section.

```
<UserSecretsId>ID goes here</UserSecretsId>
```

This is how individual secret files are found and associated with projects
You are going to have to add one more line to the csproj file in the same ItemGroup 
as your AspNetCore

```
<DotNetCliToolReference Include="Microsoft.Extensions.SecretManager.Tools" Version="2.0.0" />
```

Now we have the user secrets enabled and your secret.json ready to use

## Accessing the user secrets from within your controllers

We are going to access our secrets using the configuration API that we setup in 
our startup.cs file. To do that we need to replace our default 
configuration with one we are building from the project files and the 
secret.json file. Add the following to your startup constructor.

```
public IConfiguration Configuration { get; }

public Startup(IConfiguration configuration)
{
    var builder = new ConfigurationBuilder().AddEnvironmentVariables();
    builder.AddUserSecrets<Startup>();
    Configuration = builder.Build();
}
```

This is how our configuration gets build.  
Don't forget the `.AddEnvironmentVariables()` extension. Your local secrets 
will work without it but any deployed project will not.
Now we need access to the configuration from our controller of choice.
Bring in the configuration using statement at the top of your controller.

```
using Microsoft.Extensions.Configuration;
```

Then pass the configuration into the controller constructor, using dependency injection,
just like have done with our DBContext.

```
private readonly ImagesContext _context;
private readonly IConfiguration Configuration;

public ImageController(ImagesContext context, IConfiguration configuration)
{
    _context = context;
    Configuration = configuration;
}
```
You can now access your secrets using the `Configuration["KEYVALUEHERE"]`

```
client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", 
                Configuration["myBingAPIKey"]);
```

Your local project is now ready to go. No more worries about uploading api 
keys and passwords to git. However since our secret.json file is not deployed 
with your project that production version on Azure is now missing some important 
stuff.

Fortunately Azure has a simple way for us to add in user secret data like this. 
Follow these steps within your Azure Portal:
1. Go to your App Services
2. Select the site you are working on
2. In the left hand navigation, select application settings 
4. Under the "App Setting" you can add in user secret data. 
Azure sees this environment variable data.


## Resources
- [Managing User Secrets](https://blogs.msdn.microsoft.com/mihansen/2017/09/10/managing-secrets-in-net-core-2-0-apps/){:target="_blank"}
- [User Secrets in .NET Core 2.0](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=visual-studio){:target="_blank"}
