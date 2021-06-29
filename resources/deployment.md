# Azure Deployment Instructions

## Deploying the database

1. Navigate to `portal.azure.com`
1. On the Azure Portal sidebar, select `SQL Databases`
1. On the top, underneath the header, select `Add`
    - Fill in the required form:
       - Subscription, Choose either pay as you go, or your free trial subscription.
       - Create a new resource group (if desired)
       - Choose a database name
       - Create or select a DB Server
       - Create or select a Server (The server will contain the database):
            - Name
            - Username
            - Password
               - Save this information somewhere, you might need it later
               - Use a unique password. TAs or instructional staff might need access to it in order to help you
            - Keep location at it's default
            - Allow access
       - Wait for the process to finish.
       - Click `Select` to generate the new server
       - Select No to SQL elastic pool
       - Under `Compute + storage`, select "Configure Database"
       - Choose "Basic" and select `Apply`
       - Select "Review + Create"
       - Review your configurations
       - Select `Create`
  
1. Wait for your database to complete creation.
1. You can view your SQL Database by either selecting "Go to Resource" or reselecting the "SQL Database" on the sidebar
1. Once you are in your resource click the `Show database connection strings`
     - Select ADO.net
     - ADO.net directly works with SQL Server
     - Copy your connection string to a temporary external location (such as a notepad). It contains everything required to establish a connection to the server. You will be slightly modifying the connection string before transferring it to your application
     - Add the username of the server you just created to your connection string after `Username=` (delete the `{your_username}` and replace it with your username)
     - Add the password of the server you just created to your connection string after `Password=` (delete the `{your_password}` and replace it with your password)
     - Paste the connection strings into user secrets as `ProductionConnection`
     - Transfer your `DefaultConnection` from the `appsettings.json` file into user secrets.
	 - Delete your `appsettings.json` file.
     - Use the `ConnectionStrings:ProductionConnection` string in your `Startup.cs` file.
         - `options.UseSqlServer(Configuration["ProductionConnection"])`
         - If this doesn't work. Just use `ProductionConnection` as Configuration's argument.
     - When you use `update-database` you might get a firewall error.
         - This needs to be resolved in Azure
         - Go to the database you are trying to access
         - Click `Set server Firewall`
         - Click the plus sign
         - It should populate your IP automatically.
         - Click `Save`
     - Once the firewall error is completed, you should be able to update your database remotely.
     - Use a database manager to access your created server (You can get your server name in azure. It should end in `database.windows.net`)
     - This should effectively deploy your database.
	 - Once your initial production database has successfully been created and deployed, you may modify your DBContext registration to the following to help with local and production environments:

``` csharp
services.AddDbContext<StudentEnrollmentDbContext>(options =>
options.UseSqlServer(Configuration[s"ConnectionStrings:DefaultConnection"]));
```

## Deploying the Web App

1. Right click the project and click publish.
1. Create or select an App Service
     - Make sure that your Microsoft account is the account you used to register with Azure (top right corner)
     - Fill out the form:
         - Your app name needs to be unique to the world
         - Select your Subscription
         - Select your Resource Group
         - Don't worry about Hosting Plan or Application Insights
1. Click `Create`
     - Wait for the process to continue
1. Within your Azure Portal, select `App Services` from the side menu
1. Select your newly created Web App
1. Select `Configuration`
1. Within the `Application Settings` tab in Configuration:
     - Application Settings
       - Api Keys go in here
     - Connection Settings
       - Connection Strings go in here
     - Add a connection string (type should be SQLAzure)
       - Remove the quotes from the connection string.
1. Find your App Server's virtual IP address and add that to your firewall rules within your SQL database. 
    - Within your specific Azure App Service overview, select the "Properties" tab (located under Settings).
    - Locate your virtual IP address
    - Navigate back to your SQL database and add a new Firewall rule
    - Add the virtual IP address into the rule. Save the rule. 
1. Test your URL and confirm your website is running. Don't forget to test a page that requires a database call.
  
## How to update your deployed Application
  - Databases
    - Run the update database command in Package Manager Console
  - Web App
    - Right click and re-click the `Publish` button.
