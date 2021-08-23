using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Accounts
{
  public class CreateModel : PageModel
  {

    //  Service
    public IPerson peopleService { get;  }

    [BindProperty]
    public AddViewModel Input { get; set; }

    // Constructor
    public CreateModel(IPerson service)
    {
      peopleService = service;
    }

    public void OnGet()
    {
      // Returns the view ...
    }

    public async Task OnPostAsync()
    {
      Person person = new Person()
      {
        Name = Input.Name , // whatever they typed in
        Age = Input.Age // whatevder they typed in
      };

      Person record = await peopleService.Create(person);

      // Redirect
      // Give a message
      // ...
    }

    public class AddViewModel
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }

  }
}
