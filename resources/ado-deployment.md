# Deployment to Azure from ADO

## Configure your services

> NOTE: Regions are important. Choose a region close to you, geographically, and always choose the same region for all of your services.

1. Login to portal.azure.com.
1. Create or select a resource group.
1. Add a database
   - Choose "Azure SQL"
   - When prompted, choose the "Single Database" option from the "SQL Databases" box
   - Configuration Screen
     - Give your database a unique name
     - For the "Server" option, you'll likely need to click "Create New" as you won't yet have a server running.
       - Give your server a unique name, admin user name, password
       - Choose the same region as your resource group
     - Select the server
     - Select "No" for use SQL Elastic Pool
     - Configure Database: This option will have you choose the server plan
       - Select "Basic" from the drop down list. This is the cheapest option
         - Be sure and review the pricing shown before you continue!
     - Once the database is built, open it from the Azure Portal screen
       - Click the "Connection Strings" link from the left menu
         - Copy the "ADO.NET" string to your clipboard
       - Click the "Firewalls and virtual networks" link from the left menu
         - Turn on the option allowing Azure services to access the server
1. Add a "Web App"
   - Configuration Notes:
     - Use the same Region as your resource group
     - Runtime Stack: .NET 5, Windows
     - Sku and Size: Choose the free "F1" plan
   - Click the Create button to create the app
1. Once the application is deployed successfully, click it from the Azure portal to open it's details
   - Choose the "Deployment Center" link from the left menu
     - Use the form to find your repository and branch
     - Click the "Save" button at the top of the screen to initiate the deployment process
   - Click the "Configuration" link from the left menu
     - Once open, navigate to the bottom and click the "New Connection String" link
       - In the form, enter `DefaultConnection` for the name
       - Paste in your DB Connection string
       - Choose SQLAzure for the database type
   - Click the "Save" button at the top of the screen

At this point, your web app and database should be properly setup for use.

You can find your application's URL on the Web App screen in Azure
