## User Registration

1. (Developer 1 & 3) As a user, I would like to register for an account on the site, so that I can have a personalized experience.
1. (Developer 1 & 2) As a user, I would like to securely login to my account so that I can have a personalized experience on the site.
1. (Developer 2) As a user, I would like to see products available for sale so that customers can browse through the inventory for purchase.



- Scaffold out the admin dashboard workflow using MVC with mock data
  - What pages do you need?
  - What data do you need to make each page function properly?
- What Data Models, Navigation Properties or DTOs do you need?
  - An ERD is a great place to start
- Do you need any view models?
- Configure your core:  `DbContext` with seed data, Interfaces/Services, Routing


**User Story 1:** Add identity to your MVC project. This is done in the Startup.cs class in the ConfigureServices() method. This is a big user story because the following must also be completed to accomplish this story:
1. Create an ApplicationUser (that derives from Identity User)
1. Create a new DBContext for Identity (ApplicationDbContext) and register it into the startup
1. Setup UserSecrets into your application
1. Include app.UseAuthentication in your Configure() method within Startup.cs. Place this **after** the `app.UseRouting()`.
1. Within the `ConfigureServices()` method, add the Identity service by registering your ApplicationUser with your Identity DbContext

```
services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
```


Next, You will have to create the actual Register page:

1. Enable the use of Razor Pages into your application within the `Configure()` method within your `Startup.cs` file
1. Create a new "Pages" directory at the root of your site, followed by an "Account" directory inside "Pages".
1. Within the "Account" directory, add a new "Razor Page" and name it "Register". By default, you are only given an "OnGet" method. Using the demo code as a reference, complete the rest of the registration logic. A View Model may be a good idea to create so that you can capture the Email, Password, and Confirm Password at minimum.
1. Don't forget your `_ViewImports` file to enable your tag helpers!
1. Ensure that once a user is "created" the entry is successfully added to the database and they are redirected back home.

**User story 2:** This user story is about creating a page for users to log in. Add a new razor page named `Login` to the "Accounts" folder located in the "Pages" directory. Once your setup is complete, confirm that an already registered user can successfully log into the site.

**User story 3:** This user story will require the setup of a database. Name this database `StoreDbContext`. Register it in the Startup.cs file. This user story will also require you to implement the repository design pattern
1. If you haven't created an interface from lab 26, do so today.
1. Populate the interface with signatures that will represent basic CRUD operations within the inventory for products such as `Create`, `GetAll`, `GetByID`, `Update`, `Delete`.
  - The actual method signatures within your interface will vary and may not be those
    exact 5 methods.
1. Create a new service called `InventoryManagement` that implements your interface.
  - You won't be using this service right away, but create the interface and service to help prep you for a future sprint.
  - You will create the `ProductsController` in a future sprint. No need to create it now.
1. Be sure to add the DbContext reference to your interface so that you have access to the db.
1. Confirm you have registered your interface in your startup class
1. Bring your interface into your Controller when you need to reference it.

Finally, seed your database with 10 default products. Within your "Product" Model, have properties to hold basic information about a Product such as: ID(int), Sku(string), Name(string), Price(decimal), Description(string), Image(string).

Use [this resource](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding){:target="_blank"} to assist in syntax and population of seeding the database.


## Tests

1. Test the getter/setters of your `Product` model.
1. Test the CRUD capabilities of your interface.

## Rubric

Review the final Sprint 1 submission for rubric/breakdown of all user stories

## To Submit this Assignment

Submit the answer to the following questions:
1. What suprised you most about this milestone?
1. How long did it take you to complete this milestone?
1. How long did you expect to take?
1. What did you find most challenging about this milestone?
1. What do you need to continue to work on during this project?
1. Any Concerns that the instructional staff should be aware of?


---


BLOB

### User Stories

1. (Developer 2) As a User, I would like the images of my products to be stored securely and external to the project.
1. (Developer 1 & 3) As a user, I would like the home page to showcase and reflect the products that we are selling.
1. (Developer 1) As a user, I would like to be able to easily login and register for the site from the home page so that the user can quickly get started.
1. (Developer 1) As a user, I would like to have an administrative role available within the application.

### Guidance

**User Story 1:** Use Azure to store all of your assets.
1. Create a new page that allows authorized the user to modify products.
2. Lock this page down so that only admins can access (dependency: user story 4 for Developer 1)
3. Have the saved images go straight to Azure Blob.
4. You will receive a url back from Azure, that should be stored in your database, and referenced as the image for your product.

**User Story 2:** Add some HTML and CSS to your home page. Customize it so that it is tailored to your product you are selling.
Some ideas may be to "feature" products on your homepage! Have fun, make it look professional. In addition, add navigation to all of your external pages. Don't worry about showcasing all 10 products, we will make a page for that in lab 29. Just introduce your product on this home page.

**User Story 3:** Within your Homepage, include a link to easily Register or Login. Traditionally, these are located in your
homepage navigation. This link can just redirect to the appropriate page. We will build onto this functionality once the user is logged in during Milestone 3, so don't stress about customizing the login/logout experience just yet.

**User Story 4:**  Set your application up so that at minimum single role of Admin, and an administrative user is pre-populated into the application. Register a new policy named "AdminOnly" that only allows the Admin role access to specific pages. Use your AsyncInn labs as a resource.
