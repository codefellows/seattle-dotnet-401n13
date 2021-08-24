using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentsDemo.Components
{
  public class LoggedInUser : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync()
    {
      {
        string username = HttpContext.Request.Cookies["Username"] != null ? HttpContext.Request.Cookies["Username"] : "";

        ViewModel user = new ViewModel() { username = username };

        return View(user);

      }
    }

    public class ViewModel
    {
      public string username { get; set; }
    }
  }
}
