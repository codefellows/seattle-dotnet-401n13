using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services.Interfaces;

namespace RazorPages.Pages.Accounts
{
  public class RegisterModel : PageModel
  {

    public IPerson peopleService { get; }

    [BindProperty]
    public RegisterViewModel Input { get; set; }

    public RegisterModel(IPerson service)
    {
      peopleService = service;
    }
    public void OnGet()
    {
      // Renders whatever is in the .cshtml file
    }

    public async Task OnPostAsync()
    {
      // do the work
      // save to a database or call an api, or whatever

      Person person = new Person()
      {
        Name = Input.Name,
        Age = Input.Age
      };

      Person record = await peopleService.Create(person);

      // what do we do now??
      // Redirect to /accounts page?
      // Make a status field and render that
      // Re-Render with errors....
    }

    public class RegisterViewModel
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }

  }
}
