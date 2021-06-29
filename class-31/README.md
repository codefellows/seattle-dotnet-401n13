# Razor Pages

Razor Pages is a newer, simplified web application programming model. It removes much of the ceremony of ASP.NET MVC by adopting a file-based routing approach. Each Razor Pages file found under the Pages directory equates to an endpoint.

## Learning Objectives

### Students will be able to

#### Describe and Define

- Razor Pages
  - Pros and Cons
  - Comparisons to MVC

#### Execute

- A page based workflow using Razor Pages

## Today's Outline

<!-- To Be Completed By Instructor -->



## Learning Objectives
1. Students will be introduced to Razor Pages.
1. Students will be introduced to MVVM and how Razor Pages can live within an MVC application.
1. Students will learn about the `PageModel` and its function within Razor Pages.

## Lecture Outline

### Razor Pages

Razor Pages are new to .NET Core specifically and are an alternative architectural pattern to how your site is constructed. It still utulizes MVC and it's routing, but is more of an MVVM approach to web developement.

The advantage of razor pages is there is a lot less "magic" happening. This means that we have a bit more control, as developers, of what is happening in the data flow pipeline.

### Why

Razor Pages allow us to really utulize the "Single Responsibility" principle within practice. This means that we can gaurantee that our Models are really only doing "one" thing and only one thing.

### How

Razor Pages are enabled through the startup file.
1. Add `endpoints.MapRazorPages();` to your Startup file under `Configure()`
2. Create a `Pages` directory in the root of your site
3. Place all Razor Pages in this directory


`OnGet()` - The reserved method name that will retreive the data for the page on load.

`OnPost()` - The reserved method that gets called when a form is posted back to the Page Model.



-------
## Learning Objectives
1. Students will learn about View Component rendering.
1. Students will learn about the logic manipulation of View Components
1. Students will learn about how View Components can be used as "mini controllers"

## Lecture Outline

1. Sprint 1 is due!
   - Review the rubric for sprint 1 before submitting. Confirm you have met all of the requirements.
    - All submissions MUST be deployed to Azure!

2. Welcome to Sprint 2!

2. View Components - Small reusable components that can be seperated out into it's own "mini controller" that can be called as needed on cshtml pages.

