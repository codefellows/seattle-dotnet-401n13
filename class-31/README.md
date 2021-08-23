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


Razor Pages are new to .NET Core specifically and are an alternative architectural pattern to how your site is constructed. It still utulizes MVC and it's routing, but is more of an MVVM approach to web developement.

The advantage of razor pages is there is a lot less "magic" happening. This means that we have a bit more control, as developers, of what is happening in the data flow pipeline.


Razor Pages allow us to really utulize the "Single Responsibility" principle within practice. This means that we can gaurantee that our Models are really only doing "one" thing and only one thing.

### How

Razor Pages are enabled through the startup file.
1. Add `endpoints.MapRazorPages();` to your Startup file under `Configure()`
2. Create a `Pages` directory in the root of your site
3. Place all Razor Pages in this directory


`OnGet()` - The reserved method name that will retreive the data for the page on load.

`OnPost()` - The reserved method that gets called when a form is posted back to the Page Model.
