# View Components

View Components perform a similar role to Tag Helpers and Partial Pages. They generate HTML and are designed to represent reusable snippets of UI that can help break up and simplify complex layouts, or that can be used in multiple pages

## Learning Objectives

### Students will be able to

#### Describe and Define

- View Components
  - Best Practices
  - Use Cases

#### Execute

- Build a reusable, data-backed view component

## Notes

In addition to the standard view model associated to every razor page, when you are in the Identify Framework, you can also access the user information.

For example:

```csharp
<h1>Admin: @User.IsInRole("admin").ToString()</h1>
<h1>Editor: @User.IsInRole("editor").ToString()</h1>
<h1>Guest: @User.IsInRole("guest").ToString()</h1>

<div>@if( @User.Identity.IsAuthenticated ) { <span>Welcome Back, @User.Identity.Name</span> } </div>
```
