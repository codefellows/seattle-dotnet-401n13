using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Accounts
{
  public class PersonModel : PageModel
  {

    public string Id;
    public void OnGet(string id)
    {
      Id = id;
    }
  }
}
