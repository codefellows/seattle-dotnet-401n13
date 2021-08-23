using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages
{
  public class IndexModel : PageModel
  {
    public string Name { get; set; }

    [BindProperty]
    public List<Person> People { get; set; }

    private readonly IPerson peopleService;

    // Constructor to initialize the service we get from DI
    public IndexModel(IPerson service)
    {
      peopleService = service;
    }

    // name is sourced by the URL (passed in)
    public async Task OnGet( string name )
    {
      Name = name;
      People = await peopleService.GetAll();
    }
  }
}
