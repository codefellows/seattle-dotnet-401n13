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
  public class IndexModel : PageModel
  {
    public string Name { get; set; }

    [BindProperty]
    public List<Person> People { get; set; }

    private readonly IPerson peopleService;

    public IndexModel(IPerson service)
    {
      peopleService = service;
    }

    public async Task OnGet(string name)
    {
      Name = name; /// sends name to the view ...
      People = await peopleService.GetAll();
    }
  }
}
